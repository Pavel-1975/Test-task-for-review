using UnityEngine;
using UnityEngine.Events;

public abstract class GameMenedger : MonoBehaviour
{
    protected Transform CameraLeftNear;
    protected Transform CameraRightNear;
    protected Transform CameraLeftBehind;

    public int MaxLife { get; private set; } = 10;
    public int TotalScore { get; private set; }
    public int CurrentResult { get; private set; }
    public int BestResult { get; private set; }
    public bool Alive { get; private set; } = true;

    private int _currentStandardLiving;

    private readonly float _minSpeed = 0.05f;
    private readonly float _maxSpeed = 0.15f;

    private static float _acceleration;
    private readonly float _fixedAcceleration = 0.001f;

    private readonly int _minScore = 1;
    private readonly int _maxScore = 3;

    private float _hundredthPartX;
    private float _hundredthPartY;
    private float _hundredthPartZ;

    public event UnityAction<int> TransferCurrentResult;
    public event UnityAction<int> TransferTotalScore;
    public event UnityAction<int> TransferBestResult;
    public event UnityAction<int> TransferDamage;
    public event UnityAction Pause;


    private void Awake()
    {
        RestartGame();

        LoadData();
    }

    private void LoadData()
    {
        SaveGameData data = GetComponent<SaveGame>().OnLoadGame();

        if (data != null)
        {
            TotalScore = data.TotalScore;

            BestResult = data.BestResult;

            SendTotalScore();
            SendBestResult();
        }
    }

    public void EnrollScoresForDistroy()
    {
        CurrentResult += Random.Range(_minScore, _maxScore);

        SendCurrentResult();
    }

    public void EnrollDamagePlayer()
    {
        _currentStandardLiving -= Random.Range(_minScore, _maxScore);

        SendDamage();

        if (_currentStandardLiving <= 0)
        {
            Alive = false;

            Pause?.Invoke();
        }
    }

    public void RestartGame()
    {
        _currentStandardLiving = MaxLife;

        TotalScore += CurrentResult;

        SendDamage();
        SendBestResult();
        SendTotalScore();

        CurrentResult = 0;
        Alive = true;

        SendCurrentResult();

        Pause?.Invoke();
    }

    public float GetRandomSpeed()
    {
        _acceleration += _fixedAcceleration;

        return Random.Range(_minSpeed + _acceleration, _maxSpeed + _acceleration);
    }

    protected Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1);
    }

    //Êàìåðó ìîæíî äâèãàòü, íî íå âðàùàòü.
    protected Vector3 GetPosition()
    {
        float z = Random.Range(CameraLeftNear.position.z, CameraLeftBehind.position.z);

        float percentZ = (z - CameraLeftNear.position.z) / _hundredthPartZ;

        float X = percentZ * _hundredthPartX;
        float Y = percentZ * _hundredthPartY;

        float y = CameraLeftNear.position.y + Y;

        float x = Random.Range(CameraLeftNear.position.x - X, CameraRightNear.position.x + X);

        return new Vector3(x, y, z);
    }

    protected void CalculatePercent()
    {
        float onePercent = 0.001f;

        _hundredthPartX = System.Math.Abs(CameraLeftNear.position.x - CameraLeftBehind.position.x) * onePercent;
        _hundredthPartY = System.Math.Abs(CameraLeftNear.position.y - CameraLeftBehind.position.y) * onePercent;
        _hundredthPartZ = System.Math.Abs(CameraLeftNear.position.z - CameraLeftBehind.position.z) * onePercent;
    }

    protected void SendCurrentResult()
    {
        TransferCurrentResult?.Invoke(CurrentResult);
    }

    private void SendTotalScore()
    {
        TransferTotalScore?.Invoke(TotalScore);
    }

    private void SendBestResult()
    {
        if (CurrentResult > BestResult)
            BestResult = CurrentResult;

        TransferBestResult?.Invoke(BestResult);
    }

    private void SendDamage()
    {
        TransferDamage?.Invoke(_currentStandardLiving);
    }
}
