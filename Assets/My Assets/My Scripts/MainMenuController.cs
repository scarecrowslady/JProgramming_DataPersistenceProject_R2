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
    public TMP_Text previousHighScore;

    public bool colorSelected;
    public bool difficultySelected;

    private void Start()
    {
        colorSelected = false;
        difficultySelected = false;

        previousHighScore.text = "HiScore: " + StateGameController.HiScore + "";
    }

    private void Update()
    {

    }

    public void SetColor(Vector4 playerColor)
    {
        Debug.Log("color is: " + playerColor);

        StateGameController.PlayerColor = playerColor;

        colorSelected = true;
    }

    public void SetDifficulty(string input)
    {
        StateGameController.difficulty = input;

        difficultySelected = true;
    }

    public void StartGame()
    {
        if (colorSelected == true && difficultySelected == true)
        {
            StateGameController.HiScore = 0;
            StateGameController.MoneySaved = 0;
            StateGameController.AlienRlshpScore = 0;
            StateGameController.InventoryRockCount = 0;
            StateGameController.InventoryDebrisCount = 0;
            StateGameController.InventoryBountyCount = 0;

            SceneManager.LoadScene("Game");
        }

    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Color playerColor;
        playerColor.r = data.playerColor[0];
        playerColor.g = data.playerColor[1];
        playerColor.b = data.playerColor[2];
        playerColor.a = data.playerColor[3];
        StateGameController.PlayerColor = playerColor;

        float hiScore;
        hiScore = data.hiScore;
        StateGameController.HiScore = hiScore;

        float moneySaved;
        moneySaved = data.moneySaved;
        StateGameController.MoneySaved = moneySaved;

        float alienRlshpScore;
        alienRlshpScore = data.alienRlshpScore;
        StateGameController.AlienRlshpScore = alienRlshpScore;

        float inventoryRockCount;
        inventoryRockCount = data.inventoryRockCount;
        StateGameController.InventoryRockCount = inventoryRockCount;

        float inventoryDebrisCount;
        inventoryDebrisCount = data.inventoryDebrisCount;
        StateGameController.InventoryDebrisCount = inventoryDebrisCount;

        float inventoryBountyCount;
        inventoryBountyCount = data.inventoryBountyCount;
        StateGameController.InventoryBountyCount = inventoryBountyCount;

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
