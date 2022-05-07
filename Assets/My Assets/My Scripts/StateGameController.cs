using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameController : MonoBehaviour
{
    //setting difficulty
    public static string difficulty;

    //setting player body color
    private static Color playerColor;

    //setting hiscore
    private static float hiScore;

    //setting inventory
    private static float moneySaved;
    private static float alienRlshpScore;
    private static float inventoryRockCount;
    private static float inventoryDebrisCount;
    private static float inventoryBountyCount;

    public static Color PlayerColor { get => playerColor; set => playerColor = value; }

    public static float HiScore { get => hiScore; set => hiScore = value; }

    //getting and setting inventory values
    public static float MoneySaved { get => moneySaved; set => moneySaved = value; }
    public static float AlienRlshpScore { get => alienRlshpScore; set => alienRlshpScore = value; }
    public static float InventoryRockCount { get => inventoryRockCount; set => inventoryRockCount = value; }
    public static float InventoryDebrisCount { get => inventoryDebrisCount; set => inventoryDebrisCount = value; }
    public static float InventoryBountyCount { get => inventoryBountyCount; set => inventoryBountyCount = value; }

}
