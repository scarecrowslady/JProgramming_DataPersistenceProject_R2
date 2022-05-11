using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    // game UI text
    [SerializeField]
    private TMP_Text difficultyText;
    [SerializeField]
    private TMP_Text playerHealthText;    
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text showMoney;
    [SerializeField]
    private TMP_Text showRlshp;
    [SerializeField]
    private TMP_Text showRocks;
    [SerializeField]
    private TMP_Text showDebris;
    [SerializeField]
    private TMP_Text showBounty;

    //player info
    public PlayerController player;
    public GameObject playerRB;

    //game ui panel
    public GameObject mainGameUIPanel;
    public GameObject pauseGamePanel;

    //player health
    public float playerHealth;

    //player name
    [SerializeField]
    private TMP_Text playerName;
    public float playerHiScore;

    //player hiscore
    [SerializeField]
    private TMP_Text gameReturnHiScore;

    private void Start()
    {       
        difficultyText.text = MainManager.Instance.DifficultyLevel;

        playerName.text = MainManager.Instance.PlayerName;
        playerHealthText.text = "Shields: " + MainManager.Instance.PlayerHealth + "";

        scoreText.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";

        showMoney.text = "Money: " + MainManager.Instance.MoneySaved + "";
        showRlshp.text = "Alien Relationship: " + MainManager.Instance.RlshpScore + "";
        showRocks.text = "Rocks: " + MainManager.Instance.InvRockCount + "";
        showDebris.text = "Debris: " + MainManager.Instance.InvDebrisCount + "";
        showBounty.text = "Bounty: " + MainManager.Instance.InvBountyCount + "";

        mainGameUIPanel.SetActive(true);
        pauseGamePanel.SetActive(false);

        Time.timeScale = 1;

        MainManager.Instance.IsGameSaved = false;
    }

    private void Update()
    {
        if(MainManager.Instance.PlayerHealth <= 0)
        {
            GameOverScreen();
        }
    }

    public void GoBack()
    {
        Time.timeScale = 0;

        gameReturnHiScore.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";

        SaveGame();
        SceneManager.LoadScene("Main");
    }

    public void AddingScore(float amount)
    {
        MainManager.Instance.PlayerHiScore += amount;

        scoreText.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";
    }

    public void AddMoney(float amount)
    {
        MainManager.Instance.MoneySaved += amount;

        showMoney.text = "Money: " + MainManager.Instance.MoneySaved + "";
    }

    public void AddRlshp(float amount)
    {
        MainManager.Instance.RlshpScore += amount;

        showRlshp.text = "Relationship: " + MainManager.Instance.RlshpScore + "";
    }

    public void MinusRlshp(float amount)
    {
        MainManager.Instance.RlshpScore -= amount;

        showRlshp.text = "Relationship: " + MainManager.Instance.RlshpScore + "";
    }

    public void AddRocks(float amount)
    {
        MainManager.Instance.InvRockCount += amount;

        showRocks.text = "Rocks: " + MainManager.Instance.InvRockCount + "";
    }

    public void AddDebris(float amount)
    {
        MainManager.Instance.InvDebrisCount += amount;

        showDebris.text = "Debris: " + MainManager.Instance.InvDebrisCount + "";
    }

    public void AddBounty(float amount)
    {
        MainManager.Instance.InvBountyCount += amount;

        showBounty.text = "Bounty: " + MainManager.Instance.InvBountyCount + "";
    }
    
    public void ManagePlayerHealth(float amount)
    {
        MainManager.Instance.PlayerHealth += amount;

        playerHealthText.text = "Shields: " + MainManager.Instance.PlayerHealth + "";
    }

    public void SaveGame()
    {
        //Debug.Log("Saved");

        MainManager.Instance.IsGameSaved = true;
        MainManager.Instance.SaveInfo();
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;

        mainGameUIPanel.SetActive(false);
        pauseGamePanel.SetActive(true);
    }
}
