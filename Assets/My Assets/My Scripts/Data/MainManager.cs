using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    #region "data enclosed"
    public bool IsGameSaved;
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

    #endregion

    private void Awake()
    {
        if(Instance != null)
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
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        data.IsGameSaved = IsGameSaved;
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
        }
        else
        {
            Debug.Log("there is no save file");
        }
    }
}
