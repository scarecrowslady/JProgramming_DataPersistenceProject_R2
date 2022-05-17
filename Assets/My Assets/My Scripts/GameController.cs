using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    #region initializing stuff
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
    public float playerSpeed;
    public Vector3 playerStarterPOS;
    private Vector3 playerCurrentPOS;
    private Vector3 playerNewPOS;

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

    //for hiscores
    public string lastPlayerName;
    public float lastPlayerScore;
    public string bestPlayerName;
    public float bestPlayerScore;

    //levels
    public TMP_Text levelDisplay;
    public string levelName;
    public float levelNumber;
    public bool isLevelEnded;

    //level time limit
    public TMP_Text timeCountdown;
    public int secondsLeft = 60;
    public bool isReset = false;

    //citadel
    public GameObject citadelPFB;
    public GameObject citadelSpawnZone;
    private Vector3 citadelParkingArea;

    #endregion

    private void Start()
    {
        //initializing player
        playerRB.gameObject.SetActive(true);

        //initialize opening display
        difficultyText.text = MainManager.Instance.DifficultyLevel;
        playerName.text = MainManager.Instance.PlayerName;
        playerHealthText.text = "Shields: " + MainManager.Instance.PlayerHealth + "";
        scoreText.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";
        showMoney.text = "Money: " + MainManager.Instance.MoneySaved + "";
        showRlshp.text = "Alien Relationship: " + MainManager.Instance.RlshpScore + "";
        showRocks.text = "Rocks: " + MainManager.Instance.InvRockCount + "";
        showDebris.text = "Debris: " + MainManager.Instance.InvDebrisCount + "";
        showBounty.text = "Bounty: " + MainManager.Instance.InvBountyCount + "";    
        timeCountdown.text = "00:" + MainManager.Instance.timeTaken;

        //------------------fix this: changing level number to an instance data that is saved and returned when reloading
        levelDisplay.text = "Level " + levelNumber + "" + ":" + levelName;

        //controlling game states
        mainGameUIPanel.SetActive(true);
        pauseGamePanel.SetActive(false);

        Time.timeScale = 1;

        MainManager.Instance.IsGameSaved = false;
        MainManager.Instance.IsGameEnded = false;
        MainManager.Instance.isLevelEnded = false;

        //player starting position
        playerStarterPOS = playerRB.transform.position;

        //registering time
        secondsLeft = MainManager.Instance.timeTaken;

        //entering citadel animation
        playerStarterPOS = playerRB.transform.position;
        citadelParkingArea = citadelPFB.transform.position;

        isLevelEnded = false;
    }

    private void Update()
    {
        if (MainManager.Instance.PlayerHealth <= 0)
        {
            MainManager.Instance.IsGameEnded = true;

            MainManager.Instance.lastPlayerName = MainManager.Instance.PlayerName;
            MainManager.Instance.lastPlayerScore = MainManager.Instance.PlayerHiScore;

            if (MainManager.Instance.PlayerHiScore > MainManager.Instance.bestPlayerScore)
            {
                MainManager.Instance.bestPlayerScore = MainManager.Instance.PlayerHiScore;
                MainManager.Instance.bestPlayerName = MainManager.Instance.PlayerName;
            }

            MainManager.Instance.SaveInfo();

            GameOverScreen();
        }

        if (isReset == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        if (secondsLeft <= 0)
        {
            LevelEnded();
        }
    }

    //with a game in progress
    public void GoBack()
    {
        Time.timeScale = 0;

        SaveGame();
        SceneManager.LoadScene("Main");
    }

    //with a game ended
    public void EndedGame()
    {
        Time.timeScale = 0;

        SceneManager.LoadScene("Main");
        MainManager.Instance.IsGameSaved = false;
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

    //managing timer
    IEnumerator TimerTake()
    {
        isReset = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        if (secondsLeft < 10)
        {
            timeCountdown.text = "00:0" + secondsLeft;
        }
        else
        {
            timeCountdown.text = "00:" + secondsLeft;
        }

        MainManager.Instance.timeTaken = secondsLeft;

        isReset = false;
    }

    //managing level
    public void LevelEnded()
    {
        isLevelEnded = true;
        MainManager.Instance.isLevelEnded = true;

        Instantiate(citadelPFB);

        //enter citadel
        StartCoroutine(LevelEnding());

        Time.timeScale = 0;
        SaveGame();
        LoadCitadel();
    }

    IEnumerator LevelEnding()
    {
        isLevelEnded = true;
        MainManager.Instance.isLevelEnded = true;
        yield return new WaitForSeconds(1);

        playerCurrentPOS = playerRB.transform.position;
        playerSpeed = 4.0f;
        float step = playerSpeed * Time.deltaTime;
        playerRB.transform.position = Vector3.MoveTowards(playerCurrentPOS, playerStarterPOS, step);
        yield return new WaitForSeconds(1);

        playerNewPOS = playerRB.transform.position;
        playerSpeed = 4.0f;
        float stepNew = playerSpeed * Time.deltaTime;
        playerRB.transform.position += transform.up * stepNew;
        Debug.Log(playerRB.transform.position);
        yield return new WaitForSeconds(2);

        playerRB.gameObject.SetActive(false);
        playerRB.transform.position = playerStarterPOS;
        Debug.Log(playerRB.transform.position);
    }

    public void LoadCitadel()
    {
        SceneManager.LoadScene("Citadel");
    }

    public void SaveGame()
    {
        MainManager.Instance.IsGameSaved = true;

        MainManager.Instance.SaveInfo();
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;

        gameReturnHiScore.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";

        mainGameUIPanel.SetActive(false);
        pauseGamePanel.SetActive(true);
    }
}
