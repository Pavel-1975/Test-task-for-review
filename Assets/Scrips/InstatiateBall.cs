using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SaveGame))]
public class InstatiateBall : GameManadger
{
    [SerializeField] private BallMove _balloon;
    [SerializeField] private Transform _cameraLeftNear;
    [SerializeField] private Transform _cameraRightNear;
    [SerializeField] private Transform _cameraLeftBehind;

    private float _speedCreate = 1f;


    private void Start()
    {
        CameraLeftNear = _cameraLeftNear;
        CameraRightNear = _cameraRightNear;
        CameraLeftBehind = _cameraLeftBehind;

        CalculatePercent();

        SendCurrentResult();

        StartCoroutine(WaitForSeconds());
    }

    private void Instantiate()
    {
        Transform balloon = Instantiate(_balloon.transform, GetPosition(), Quaternion.identity, transform);

        balloon.GetComponent<BallDestroy>()._gameManadger = GetComponent<GameManadger>();
        balloon.GetComponent<BallMove>()._gameManadger = GetComponent<GameManadger>();
        balloon.GetComponent<MeshRenderer>().material.color = GetRandomColor();
        balloon.GetComponent<ParticleSystemRenderer>().material = balloon.GetComponent<MeshRenderer>().material;
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(_speedCreate);

        if (!IsPause)
            Instantiate();

        StartCoroutine(WaitForSeconds());
    }

    private void OnApplicationQuit()
    {
        RestartGame();

        GetComponent<SaveGame>().OnSaveGame();
    }
}
