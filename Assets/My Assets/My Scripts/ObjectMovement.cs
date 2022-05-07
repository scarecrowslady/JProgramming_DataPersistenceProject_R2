using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //setting speed
    public float objectSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("bullet") == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * objectSpeed);
        }
        else
        {
            transform.Translate(-Vector2.up * Time.deltaTime * objectSpeed);
        }
    }
}
