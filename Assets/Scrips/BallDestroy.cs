using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class BallDestroy : MonoBehaviour
{
    [HideInInspector] public GameManager _gameManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Floor>(out _) && GetComponent<MeshRenderer>().enabled)
        {
            _gameManager.EnrollDamagePlayer();

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!_gameManager.IsPause && GetComponent<MeshRenderer>().enabled)
        {
            _gameManager.EnrollScoresForDistroy();

            GetComponent<ParticleSystem>().Play();

            GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine(WaitForSeconds());
        }
    }

    private IEnumerator WaitForSeconds()
    {
        float seconds = GetComponent<ParticleSystem>().main.startLifetimeMultiplier;

        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }

    private void RestartGame()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _gameManager.InitRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        _gameManager.InitRestartGame -= RestartGame;
    }
}
