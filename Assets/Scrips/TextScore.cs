using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    [SerializeField] private GameMenedger _gameMenedger;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameMenedger.TransferCurrentResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameMenedger.TransferCurrentResult -= ShowScore;
    }
}
