using UnityEngine;
using TMPro;

public class TextNewHighScore : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameManager.TransferBestResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferBestResult -= ShowScore;
    }
}
