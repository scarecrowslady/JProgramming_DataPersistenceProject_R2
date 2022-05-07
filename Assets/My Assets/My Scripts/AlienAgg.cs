using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAgg : MonoBehaviour
{
    [SerializeField]
    GameObject alienBullet;

    float fireRate;
    float nextFire;

    //initialization
    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    private void Update()
    {
        if (transform.position.y < 4 && transform.position.y > -4)
        {
            CheckIfTimeToFire();
        }

    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(alienBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
