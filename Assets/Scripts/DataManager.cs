using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string highPlayerName;
    public string currentPlayerName = "";
    public int highScore;

    [System.Serializable]
    public struct PlayerData
    {
        public string name;
        public int score;

        public override string ToString()
        {
            return string.Format("PlayerData({0}, {1})", name, score.ToString());
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScoreData();
    }

    [System.Serializable]
    class SaveData
    {
        public PlayerData playerData;
    }

    public void SaveScoreData()
    {
        SaveData data = new SaveData();
        data.playerData = new();
        data.playerData.name = highPlayerName;
        data.playerData.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = $"{Application.persistentDataPath}/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highPlayerName = data.playerData.name;
            highScore = data.playerData.score;
        }
    }
}
