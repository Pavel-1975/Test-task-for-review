using UnityEngine;
using TMPro;

public abstract class Score : MonoBehaviour
{
    [SerializeField] protected GameManager _gameManager;


    protected void ShowScore(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }
}
