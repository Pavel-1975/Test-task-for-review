using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    [HideInInspector] public GameManadger _gameManadger;
    private float _speed;


    private void Start()
    {
        _speed = _gameManadger.GetRandomSpeed();

        StartCoroutine(WaitForSeconds());
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        if (!_gameManadger.IsPause)
            Move();

        StartCoroutine(WaitForSeconds());
    }

    private void Move()
    {
        transform.Translate(0f, -_speed, 0f);
    }
}
