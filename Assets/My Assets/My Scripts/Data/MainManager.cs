using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    #region "data enclosed"
    public bool IsGameSaved;
    public bool IsGameEnded;
    public bool isHighScoreTriggered;
    public string DifficultyLevel;

    public string PlayerName;
    public Color PlayerColor;
    public float PlayerHealth;

    public float PlayerHiScore;

    public float MoneySaved;
    public float RlshpScore;
    public float InvRockCount;
    public float InvDebrisCount;
    public float InvBountyCount;

    public string lastPlayerName;
    public float lastPlayerScore;

    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public bool IsGameSaved;
        public bool IsGameEnded;
        public bool isHighScoreTriggered;
        public string DifficultyLevel;

        public string PlayerName;
        public Color PlayerColor;
        public float PlayerHealth;

        public float PlayerHiScore;

        public float MoneySaved;
        public float RlshpScore;
        public float InvRockCount;
        public float InvDebrisCount;
        public float InvBountyCount;

        public string LastPlayerName;
        public float LastPlayerScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        data.IsGameSaved = IsGameSaved;
        data.isHighScoreTriggered = isHighScoreTriggered;
        data.DifficultyLevel = DifficultyLevel;

        data.PlayerName = PlayerName;
        data.PlayerColor = PlayerColor;
        data.PlayerHealth = PlayerHealth;

        data.PlayerHiScore = PlayerHiScore;

        data.MoneySaved = MoneySaved;
        data.RlshpScore = RlshpScore;
        data.InvRockCount = InvRockCount;
        data.InvDebrisCount = InvDebrisCount;
        data.InvBountyCount = InvBountyCount;

        data.LastPlayerName = lastPlayerName;
        data.LastPlayerScore = lastPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            IsGameSaved = data.IsGameSaved;
            isHighScoreTriggered = data.isHighScoreTriggered;
            DifficultyLevel = data.DifficultyLevel;

            PlayerName = data.PlayerName;
            PlayerColor = data.PlayerColor;
            PlayerHealth = data.PlayerHealth;

            PlayerHiScore = data.PlayerHiScore;

            MoneySaved = data.MoneySaved;
            RlshpScore = data.RlshpScore;
            InvRockCount = data.InvRockCount;
            InvDebrisCount = data.InvDebrisCount;
            InvBountyCount = data.InvBountyCount;

            lastPlayerName = data.LastPlayerName;
            lastPlayerScore = data.LastPlayerScore;
        }
        else
        {
            Debug.Log("there is no save file");
        }
    }
}