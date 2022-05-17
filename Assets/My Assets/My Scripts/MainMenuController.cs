using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    public bool colorSelected;
    public bool difficultySelected;
    public bool playerNameSelected;
    public TMP_InputField inputPlayerName;
    public string inputPlayerNameText;

    public string playerName;
    public Color playerColor;
    public float playerHealth;

    public GameObject errorCanvas;

    public TMP_Text lastPlayerName;
    public TMP_Text lastPlayerScore;
    public string lastPlayerNameVar;
    public float lastPlayerScoreVar;

    public TMP_Text bestPlayerName;
    public TMP_Text bestPlayerScore;
    public string bestPlayerNameVar;
    public float bestPlayerScoreVar;

    public int secondsLeft;

    private void Start()
    {
        colorSelected = false;
        difficultySelected = false;
        playerNameSelected = false;

        SetCurrentBestPlayer();
    }

    public void SetColor(Color playerColor)
    {
        MainManager.Instance.PlayerColor = playerColor;

        colorSelected = true;
    }

    public void SetDifficulty(string input)
    {
        MainManager.Instance.DifficultyLevel = input;

        difficultySelected = true;
    }

    public void SetPlayerName(string input)
    {
        MainManager.Instance.PlayerName = input;
        inputPlayerNameText = inputPlayerName.text;

        if(!string.IsNullOrEmpty(inputPlayerNameText))
        {
            playerNameSelected = true;
        }
        else
        {
            playerNameSelected = false;
        }
    }

    public void ClearHiScores()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetCurrentBestPlayer()
    {    
        lastPlayerNameVar = MainManager.Instance.lastPlayerName;
        lastPlayerScoreVar = MainManager.Instance.lastPlayerScore;

        lastPlayerName.text = "Last Player: " + lastPlayerNameVar;       
        lastPlayerScore.text = "Highscore: " + lastPlayerScoreVar + "";

        bestPlayerNameVar = MainManager.Instance.bestPlayerName;
        bestPlayerScoreVar = MainManager.Instance.bestPlayerScore;

        bestPlayerName.text = "Best Player: " + bestPlayerNameVar;
        bestPlayerScore.text = "Highscore: " + bestPlayerScoreVar + "";

        MainManager.Instance.SaveInfo();
    }

    public void StartGame()
    {
        if (colorSelected == true && difficultySelected == true && playerNameSelected == true)
        {
            MainManager.Instance.PlayerHealth = 30;

            MainManager.Instance.PlayerHiScore = 0;

            MainManager.Instance.MoneySaved = 0;
            MainManager.Instance.RlshpScore = 0;
            MainManager.Instance.InvRockCount = 0;
            MainManager.Instance.InvDebrisCount = 0;
            MainManager.Instance.InvBountyCount = 0;

            MainManager.Instance.timeTaken = secondsLeft;

            SceneManager.LoadScene("Game");
        }
        else
        {
            errorCanvas.gameObject.SetActive(true);

            //add a small error screen for players
            Debug.Log("you're missing something");
        }
    }

    public void TriggerLoadedGame()
    {
        if(MainManager.Instance.IsGameSaved == false)
        {
            Debug.Log("there is no saved game");
        }
        else
        {
            LoadGame(); 
        }
    }

    public void GoToHighScores()
    {
        SceneManager.LoadScene("HiScores");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
