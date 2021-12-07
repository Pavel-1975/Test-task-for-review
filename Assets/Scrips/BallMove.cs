using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    [HideInInspector] public GameManager _gameManager;
    private float _speed;


    private void Start()
    {
        _speed = _gameManager.GetRandomSpeed();

        StartCoroutine(WaitForSeconds());
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        if (!_gameManager.IsPause)
            Move();

        StartCoroutine(WaitForSeconds());
    }

    private void Move()
    {
        transform.Translate(0f, -_speed, 0f);
    }
}
