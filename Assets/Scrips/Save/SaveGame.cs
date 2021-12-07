//C:\Users\Vektorrus\AppData\LocalLow\DefaultCompany\Test task for review
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public string NameFile { get; private set; } = "/Balloon.dat"; 

    //##########################
    [SerializeField] private GameManager _gameManager;

    public GameManager GameManager => _gameManager;


    public void OnSaveGame()
    {
        SaveLoad.SaveGame(this);       
    }

    public SaveGameData OnLoadGame()
    {
        return SaveLoad.LoadGame(this);
    }
}
