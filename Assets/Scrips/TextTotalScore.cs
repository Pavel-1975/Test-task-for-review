using UnityEngine;
using TMPro;

public class TextTotalScore : MonoBehaviour
{
    [SerializeField] private GameMenedger _gameMenedger;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameMenedger.TransferTotalScore += ShowScore;
    }

    private void OnDisable()
    {
        _gameMenedger.TransferTotalScore -= ShowScore;
    }
}
