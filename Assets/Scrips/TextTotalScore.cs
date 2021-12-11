
public class TextTotalScore : Score
{
    private void OnEnable()
    {
        _gameManager.TransferTotalScore += ShowScore;
    }

    private void OnDisable()
    {
        _gameManager.TransferTotalScore -= ShowScore;
    }
}
