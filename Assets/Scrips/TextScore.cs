
public class TextScore : Score
{
    private void OnEnable()
    {
        _gameManager.TransferCurrentResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferCurrentResult -= ShowScore;
    }
}
