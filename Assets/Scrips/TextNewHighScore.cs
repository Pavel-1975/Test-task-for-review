
public class TextNewHighScore : Score
{
    private void OnEnable()
    {
        _gameManager.TransferBestResult += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferBestResult -= ShowScore;
    }
}
