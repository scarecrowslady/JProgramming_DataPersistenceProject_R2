using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreUIHandler : MonoBehaviour
{  
    private void Awake()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
