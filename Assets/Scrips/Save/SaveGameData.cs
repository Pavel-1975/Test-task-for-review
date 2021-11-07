[System.Serializable]
public class SaveGameData
{
    public int TotalScore;
    public int BestResult;


    public SaveGameData(SaveGame saveGame)
    {
        SaveDataGameMenedger(saveGame.GameMenedger);
    }

    private void SaveDataGameMenedger(GameMenedger gameMenedger)
    {
        TotalScore = gameMenedger.TotalScore;

        BestResult = gameMenedger.BestResult;
    }
}