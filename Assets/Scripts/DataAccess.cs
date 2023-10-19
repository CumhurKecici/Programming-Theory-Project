using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class DataAccess
{
    private static string SettingsFilePath = Application.persistentDataPath + "/settings.json";

    public static class Settings
    {
        public static string PlayerName { get; set; } = "Player";
        public static float BackgroundMusicVolume { get; set; } = 1;
    }

    public static void LoadSettings()
    {
        if (File.Exists(SettingsFilePath))
        {
            string json = File.ReadAllText(SettingsFilePath);

            SettingsData settingsData = JsonUtility.FromJson<SettingsData>(json);
            Settings.PlayerName = settingsData.PlayerName;
            Settings.BackgroundMusicVolume = settingsData.BackgroundMusicVolume;
        }
    }

    public static void SaveSettings()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.PlayerName = Settings.PlayerName;
        settingsData.BackgroundMusicVolume = Settings.BackgroundMusicVolume;

        string json = JsonUtility.ToJson(settingsData);
        File.WriteAllText(SettingsFilePath, json);
    }

    [Serializable]
    class SettingsData
    {
        public string PlayerName;
        public float BackgroundMusicVolume;
    }

}

