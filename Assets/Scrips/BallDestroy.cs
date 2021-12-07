using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class BallDestroy : MonoBehaviour
{
    [HideInInspector] public GameManadger _gameManadger;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Floor>(out _) && GetComponent<MeshRenderer>().enabled)
        {
            _gameManadger.EnrollDamagePlayer();

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!_gameManadger.IsPause && GetComponent<MeshRenderer>().enabled)
        {
            _gameManadger.EnrollScoresForDistroy();

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

    private void OnEnable()
    {
        _gameManadger.InitRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        _gameManadger.InitRestartGame -= RestartGame;
    }
}
