using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    //top destruction
    public float topRangeLimit;

    //bottom destruction
    public float bottomRangeLimit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topRangeLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < bottomRangeLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet") == true && (gameObject.CompareTag("res_rocks") || gameObject.CompareTag("res_debris") || gameObject.CompareTag("res_alien") || gameObject.CompareTag("aggAlien") == true))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (gameObject.CompareTag("playerKiller") == true)
        {
            Destroy(collision.gameObject);
        }        
    }
}
