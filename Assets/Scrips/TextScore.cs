using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameManager.TransferCurrentResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferCurrentResult -= ShowScore;
    }
}
