using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingPoints_2 : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("res_debris") == true)
        {
            gameManager.GetComponent<GameController>().AddDebris(2);
            gameManager.GetComponent<GameController>().AddRlshp(1);
            gameManager.GetComponent<GameController>().AddingScore(5);

            Debug.Log("Adding Debris: " + MainManager.Instance.InvDebrisCount);
        }

        if(collision.CompareTag("res_rocks") == true)
        {
            gameManager.GetComponent<GameController>().AddRocks(1);
            gameManager.GetComponent<GameController>().AddRlshp(1);
            gameManager.GetComponent<GameController>().AddingScore(5);

            Debug.Log("Adding Debris: " + MainManager.Instance.InvRockCount);
        }

        if(collision.CompareTag("res_alien") == true)
        {
            gameManager.GetComponent<GameController>().AddBounty(3);
            gameManager.GetComponent<GameController>().MinusRlshp(1);
            gameManager.GetComponent<GameController>().AddMoney(1);
            gameManager.GetComponent<GameController>().AddingScore(10);

            Debug.Log("Adding Plunder: " + MainManager.Instance.InvBountyCount);
        }

        if(collision.CompareTag("aggAlien") == true)
        {
            gameManager.GetComponent<GameController>().AddBounty(5);
            gameManager.GetComponent<GameController>().MinusRlshp(1);
            gameManager.GetComponent<GameController>().AddMoney(2);
            gameManager.GetComponent<GameController>().AddingScore(20);

            Debug.Log("Adding Plunder: " + MainManager.Instance.InvBountyCount);
        }

        if(collision.CompareTag("playerKiller") == true)
        {
            gameManager.GetComponent<GameController>().MinusRlshp(2);
        }
    }
}
