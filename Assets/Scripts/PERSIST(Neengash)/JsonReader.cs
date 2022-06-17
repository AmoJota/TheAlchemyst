using UnityEngine;
using System.IO;
using SaveSystem;

public class JsonReader
{
    public static SaveData Read(string file)
    {
        string path = Path.Combine(Application.persistentDataPath, SaveConstants.SAVE_DIR, file);
        if (!File.Exists(path)) { return null; }
        string json = File.ReadAllText(path);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        return saveData;
    }
}
