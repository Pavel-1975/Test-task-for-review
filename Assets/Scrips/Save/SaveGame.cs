//C:\Users\Vektorrus\AppData\LocalLow\DefaultCompany\Test task for review
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public string NameFile { get; private set; } = "/Balloon.dat"; 

    //##########################
    [SerializeField] private GameManadger _gameMenedger;

    public GameManadger GameMenedger => _gameMenedger;


    public void OnSaveGame()
    {
        SaveLoad.SaveGame(this);       
    }

    public SaveGameData OnLoadGame()
    {
        return SaveLoad.LoadGame(this);
    }
}
