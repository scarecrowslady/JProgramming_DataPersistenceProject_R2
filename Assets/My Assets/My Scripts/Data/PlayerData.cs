using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] playerColor;

    public float hiScore;

    public float moneySaved;
    public float alienRlshpScore;
    public float inventoryRockCount;
    public float inventoryDebrisCount;
    public float inventoryBountyCount;

    public PlayerData(PlayerController player)
    {
        playerColor = new float[4];
        playerColor[0] = player.playerBodyCol.r;
        playerColor[1] = player.playerBodyCol.g;
        playerColor[2] = player.playerBodyCol.b;
        playerColor[3] = player.playerBodyCol.a;

        hiScore = StateGameController.HiScore;
        moneySaved = StateGameController.MoneySaved;
        alienRlshpScore = StateGameController.AlienRlshpScore;
        inventoryRockCount = StateGameController.InventoryRockCount;
        inventoryDebrisCount = StateGameController.InventoryDebrisCount;
        inventoryBountyCount = StateGameController.InventoryBountyCount;
    }
}
