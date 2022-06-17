using UnityEngine;
using System.IO;
using SaveSystem;


public static class JsonWriter
{
    public static void Write(string fileName, SaveData data)
    {
        string path = Path.Combine(Application.persistentDataPath, SaveConstants.SAVE_DIR, fileName);
        if (!File.Exists(path))
        {
            string directoryPath = Path.Combine(Application.persistentDataPath, SaveConstants.SAVE_DIR);
            Directory.CreateDirectory(directoryPath);
        }
        string jsonData = JsonUtility.ToJson(data, false);

        File.WriteAllText(path, jsonData);
    }

    public static void Delete(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, SaveConstants.SAVE_DIR, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }

    }
}
