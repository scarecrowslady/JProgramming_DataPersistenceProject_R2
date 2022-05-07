using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spaceObjects;

    public float spawnRangeX;
    public float spawnPosZ;
    public float spawnPosY;

    public float startDelay;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomSpaceObjects", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomSpaceObjects()
    {
        int objectIndex = Random.Range(0, spaceObjects.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        Instantiate(spaceObjects[objectIndex], spawnPos, spaceObjects[objectIndex].transform.rotation);
    }
}