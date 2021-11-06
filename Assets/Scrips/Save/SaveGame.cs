//C:\Users\Vektorrus\AppData\LocalLow\DefaultCompany\Test task for review
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public string NameFile { get; private set; } = "/Balloon.dat"; 

    //##########################
    [SerializeField] private GameMenedger _gameMenedger;

    public GameMenedger GameMenedger => _gameMenedger;


    public void OnSaveGame()
    {
        SaveLoad.SaveGame(this);       
    }

    public SaveGameData OnLoadGame()
    {
        return SaveLoad.LoadGame(this);
    }
}
