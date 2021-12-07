[System.Serializable]
public class SaveGameData
{
    public int TotalScore;
    public int BestResult;


    public SaveGameData(SaveGame saveGame)
    {
        SaveDataGameMenedger(saveGame.GameManager);
    }

    private void SaveDataGameMenedger(GameManager gameManager)
    {
        TotalScore = gameManager.TotalScore;

        BestResult = gameManager.BestResult;
    }
}
