﻿using System.Collections;
using System.IO;
using UnityEngine;

public static class JsonManager 
{
    public static string Dir = "/SavedData/";
    public enum SaveType { Stats, Shop };
    public static SaveType myType;
    public static void Save(Stats data) {
        var gameDir = Application.persistentDataPath + Dir;
        if (!Directory.Exists(gameDir)) {
            Directory.CreateDirectory(gameDir);
        }
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(gameDir + "Campaign.txt", json);
    }
    //TODO: Needs refactor. Duplicatined code
    public static void Save(Shop data)
    {
        var gameDir = Application.persistentDataPath + Dir;
        if (!Directory.Exists(gameDir))
        {
            Directory.CreateDirectory(gameDir);
        }
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(gameDir + "Shop.txt", json);
    }
    public static Stats Load() {
        Stats data = new Stats();
        var savedDataDir = Application.persistentDataPath + Dir + "Campaign.txt";

        if (File.Exists(savedDataDir))
        {
            var json = File.ReadAllText(savedDataDir);
            data =  JsonUtility.FromJson<Stats>(json);
        }
        else
        {
            Debug.Log("File not fount with Directory: {0}" + savedDataDir) ;
            return null;
        }
        return data;
    }

    //TODO: Needs refactoring. Duplicatined code.
    public static Shop LoadShop()
    {
        Shop data = new Shop();
        var savedDataDir = Application.persistentDataPath + Dir + "Shop.txt";

        if (File.Exists(savedDataDir))
        {
            var json = File.ReadAllText(savedDataDir);
            data = JsonUtility.FromJson<Shop>(json);
        }
        else
        {
            Debug.Log("File not fount with Directory: {0}" + savedDataDir);
            return null;
        }
        return data;
    }

    public static void DeleteProgress() {
        var savedDataDir = Application.persistentDataPath + Dir + "Shop.txt";
        File.Delete(savedDataDir);
        savedDataDir = Application.persistentDataPath + Dir + "Campaign.txt";
        File.Delete(savedDataDir);
    }

}
