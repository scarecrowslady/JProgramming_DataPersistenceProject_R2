using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CitadelController : MonoBehaviour
{
    public int secondsLeft;

    public void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void UndockForMission()
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
}
