using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    private GameMenedger _gameMenedger;
    private float _speed;


    private void Start()
    {
        _gameMenedger = transform.root.GetComponent<GameMenedger>();

        _speed = _gameMenedger.GetRandomSpeed();

        StartCoroutine(WaitForSeconds());
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        if (!transform.root.GetComponent<BallContainer>().ButtonPause.IsPause)
            Move();

        StartCoroutine(WaitForSeconds());
    }

    private void Move()
    {
        transform.Translate(0f, -_speed, 0f);
    }
}
