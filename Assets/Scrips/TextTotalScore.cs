using UnityEngine;
using TMPro;

public class TextTotalScore : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameManager.TransferTotalScore += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferTotalScore -= ShowScore;
    }
}
