using System.Collections;
using System.IO;
using UnityEngine;

public static class JsonManager 
{
    public static string Dir = "/SavedData/";
    public static string FileName = "Campaing.txt";

    public static void Save(Stats data) {
        var gameDir = Application.persistentDataPath + Dir;
        if (!Directory.Exists(gameDir)) {
            Directory.CreateDirectory(gameDir);
        }
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(gameDir + FileName, json);
    }
    public static Stats Load() {
        var savedDataDir = Application.persistentDataPath + Dir + FileName;
        Stats data = new Stats();

        if (File.Exists(savedDataDir))
        {
            var json = File.ReadAllText(savedDataDir);
            data =  JsonUtility.FromJson<Stats>(json);
        }
        else
        {
            Debug.Log("File not fount with Directory: {0}" + savedDataDir) ;
        }
        return data;
    }

}
