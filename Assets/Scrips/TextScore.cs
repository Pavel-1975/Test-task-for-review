using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    [SerializeField] private GameManadger _gameManadger;


    private void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }

    private void OnEnable()
    {
        _gameManadger.TransferCurrentResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameManadger.TransferCurrentResult -= ShowScore;
    }
}
