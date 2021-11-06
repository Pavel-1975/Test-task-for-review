using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    private static string _path = Application.persistentDataPath;

    private static BinaryFormatter _formatter = new BinaryFormatter();


    public static void SaveGame(SaveGame saveGame)
    {
        FileStream fs = new FileStream(_path + saveGame.NameFile, FileMode.Create);

        SaveGameData data = new SaveGameData(saveGame);

        _formatter.Serialize(fs, data);

        fs.Close();
    }


    public static SaveGameData LoadGame(SaveGame saveGame)
    {
        if (File.Exists(_path + saveGame.NameFile))
        {
            FileStream fs = new FileStream(_path + saveGame.NameFile, FileMode.Open);

            SaveGameData data = _formatter.Deserialize(fs) as SaveGameData;

            fs.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
