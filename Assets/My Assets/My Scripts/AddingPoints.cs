using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddingPoints : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerKiller") == true)
        {
            StateGameController.AlienRlshpScore -= 1;

            Debug.Log("Adding minus rlshp");

            showRlshp.text = "Relationship: " + StateGameController.AlienRlshpScore + "";
        }

        if (collision.gameObject.CompareTag("res_debris") == true)
        {
            StateGameController.InventoryDebrisCount += 2;
            StateGameController.AlienRlshpScore += 1;

            Debug.Log("Adding debris");

            showDebris.text = "Debris: " + StateGameController.InventoryDebrisCount + "";
            showRlshp.text = "Relationship: " + StateGameController.AlienRlshpScore + "";
        }

        if (collision.gameObject.CompareTag("res_rocks") == true)
        {
            StateGameController.InventoryRockCount += 1;
            StateGameController.AlienRlshpScore += 1;

            Debug.Log("Adding rocks");

            showRocks.text = "Rocks: " + StateGameController.InventoryRockCount + "";
            showRlshp.text = "Relationship: " + StateGameController.AlienRlshpScore + "";
        }

        if (collision.gameObject.CompareTag("res_alien") == true)
        {
            //gameController.AddBounty(5);
            //gameController.MinusRlshp(1);

            Debug.Log("Adding alien");
        }

        if (collision.gameObject.CompareTag("aggAlien") == true)
        {
            //gameController.AddBounty(7);
            //gameController.MinusRlshp(2);

            Debug.Log("Adding aggAlien");
        }
    }
}
