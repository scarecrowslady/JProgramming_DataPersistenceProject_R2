using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    public string lastPlayerName;
    public float lastPlayerScore;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //if there is no stored table, initialize
        if(highscores == null)
        {
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(1234, "KAL");
            AddHighscoreEntry(345, "TAM");
            AddHighscoreEntry(897621, "JOE");

            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        //for sorting without save / load(otherwise we can sort on a load function
        //for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        //{
        //    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
        //    {
        //        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
        //        {
        //            //swap

        //            HighscoreEntry tmp = highscores.highscoreEntryList[i];
        //            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
        //            highscores.highscoreEntryList[j] = tmp;
        //        }
        //    }
        //}
        highscores.highscoreEntryList.Sort((x, y) => y.score.CompareTo(x.score));

        //keep max count and delete extra
        if (highscores.highscoreEntryList.Count > 10)
        {
            for (int h = highscores.highscoreEntryList.Count; h > 10; h--)
            {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHIghscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);            
        }
    }

    private void Update()
    {
        
    }

    private void CreateHIghscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;        

        float score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(float score, string name)
    {
        //create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //if there's no stored table, initialize
        if (highscores == null)
        {
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        //add new entry to list
        highscores.highscoreEntryList.Add(highscoreEntry);

        //keep max count and delete extra
        if (highscores.highscoreEntryList.Count > 10)
        {
            for (int h = highscores.highscoreEntryList.Count; h > 10; h--)
            {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }

        //save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //represents a single highscore entry

    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string name;
    }
}
