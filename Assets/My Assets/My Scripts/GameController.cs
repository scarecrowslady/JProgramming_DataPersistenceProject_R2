using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text difficultyText;

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

    public PlayerController player;

    //game UI stuff
    public GameObject mainGameUIPanel;
    public GameObject pauseGamePanel;

    private void Start()
    {
        mainGameUIPanel.SetActive(true);
        pauseGamePanel.SetActive(false);

        difficultyText.text = StateGameController.difficulty;

        scoreText.text = "HiScore: " + StateGameController.HiScore + "";
        showMoney.text = "Money: " + StateGameController.MoneySaved + "";
        showRlshp.text = "Alien Relationship: " + StateGameController.AlienRlshpScore + "";
        showRocks.text = "Rocks: " + StateGameController.InventoryRockCount + "";
        showDebris.text = "Debris: " + StateGameController.InventoryDebrisCount + "";
        showBounty.text = "Bounty: " + StateGameController.InventoryBountyCount + "";

        Time.timeScale = 1;
    }

    private void Update()
    {

    }

    public void GoBack()
    {
        Time.timeScale = 0;

        SaveGame();
        SceneManager.LoadScene("Main");
    }

    public void AddingScore(int amount)
    {
        StateGameController.HiScore += amount;

        Debug.Log("Adding Score");

        scoreText.text = "HiScore: " + StateGameController.HiScore + "";
    }

    public void AddMoney(int amount)
    {
        StateGameController.MoneySaved += amount;

        Debug.Log("Adding Money");

        showMoney.text = "Money: " + StateGameController.MoneySaved + "";
    }

    public void AddRlshp(int amount)
    {
        StateGameController.AlienRlshpScore += amount;

        Debug.Log("Adding Relationship");

        showRlshp.text = "Relationship: " + StateGameController.AlienRlshpScore + "";
    }

    public void MinusRlshp(int amount)
    {
        StateGameController.AlienRlshpScore -= amount;

        showRlshp.text = "Relationship: " + StateGameController.AlienRlshpScore + "";
    }

    public void AddRocks(int amount)
    {
        StateGameController.InventoryRockCount += amount;

        showRocks.text = "Rocks: " + StateGameController.InventoryRockCount + "";
    }

    public void AddDebris(int amount)
    {
        StateGameController.InventoryDebrisCount += amount;

        showDebris.text = "Debris: " + StateGameController.InventoryDebrisCount + "";
    }

    public void AddBounty(int amount)
    {
        StateGameController.InventoryBountyCount += amount;

        showBounty.text = "Bounty: " + StateGameController.InventoryBountyCount + "";
    }

    public void SaveGame()
    {
        Debug.Log("Saved");
        SaveSystem.SavePlayer(player);
    }

    public void GameOverScreen()
    {
        mainGameUIPanel.SetActive(false);
        pauseGamePanel.SetActive(true);

        Time.timeScale = 0;
    }
}
