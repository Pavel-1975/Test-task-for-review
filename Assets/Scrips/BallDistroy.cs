using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class BallDistroy : MonoBehaviour
{
    private ButtonRestart _buttonRestart;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Floor>(out _) && GetComponent<MeshRenderer>().enabled)
        {
            transform.root.GetComponent<GameMenedger>().EnrollDamagePlayer();

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!transform.root.GetComponent<BallContainer>().ButtonPause.IsPause && GetComponent<MeshRenderer>().enabled)
        {
            transform.root.GetComponent<GameMenedger>().EnrollScoresForDistroy();

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
        _buttonRestart = transform.root.GetComponent<BallContainer>().ButtonRestart;

        _buttonRestart.RestartGame += RestartGame;
    }

    private void OnDisable()
    {
        _buttonRestart.RestartGame -= RestartGame;
    }
}
