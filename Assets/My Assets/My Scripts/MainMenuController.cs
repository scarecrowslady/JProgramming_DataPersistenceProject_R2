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

    public string playerName;
    public Color playerColor;
    public float playerHealth;

    public GameObject errorCanvas;

    GameController gameController;

    private void Start()
    {
        colorSelected = false;
        difficultySelected = false;
        playerNameSelected = false;
    }

    private void Update()
    {

    }

    public void SetColor(Color playerColor)
    {
        Debug.Log("color is: " + playerColor);

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

        playerNameSelected = true;
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

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadHiScores()
    {
        SceneManager.LoadScene("HiScores");
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
