using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HiScores : MonoBehaviour
{
    public HiScoreDisplay[] highScoreDisplayArray;

    List<MainManager> scores = new List<MainManager>();

    // Start is called before the first frame update

    private void Start()
    {
        AddNewScore("nami", 654);
        AddNewScore("lil", 7841);
        AddNewScore("jane", 892);

        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        scores.Sort((MainManager x, MainManager y) => y.PlayerHiScore.CompareTo(x.PlayerHiScore));

        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].PlayerName, scores[i].PlayerHiScore);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
            
        } 
    }

    public void AddNewScore(string currentPlayerName, float currentHiScore)
    {
        scores.Add(item: new MainManager { PlayerName = currentPlayerName, PlayerHiScore = currentHiScore });
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
