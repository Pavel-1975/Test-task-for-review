using UnityEngine;
using TMPro;

public class TextNewHighScore : MonoBehaviour
{
    [SerializeField] private GameManadger _gameMenedger;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameMenedger.TransferBestResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameMenedger.TransferBestResult -= ShowScore;
    }
}
