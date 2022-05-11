using System.Collections;
using System.Collections.Generic;
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

    void UpdateDisplay()
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

    void AddNewScore(string currentPlayerName, float currentHiScore)
    {
        scores.Add(new MainManager { PlayerName = currentPlayerName, PlayerHiScore = currentHiScore });
    }
}
