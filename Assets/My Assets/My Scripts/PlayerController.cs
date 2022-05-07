using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //basic stuff
    public GameObject playerPFB;
    public SpriteRenderer playerCol;
    public Color playerBodyCol;

    //shooting bullets
    public GameObject bulletPrefab;

    //moving player
    public float horizontalInput;
    public float playerMoveSpeed;
    public float xRange;

    //triggering game states
    GameController gameManagingScript;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = playerPFB.GetComponent<SpriteRenderer>();                
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerColor();

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Instantiate(bulletPrefab, gameObject.transform.position, bulletPrefab.transform.rotation);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerMoveSpeed);
    }

    public void SetPlayerColor()
    {
        playerBodyCol = StateGameController.PlayerColor;
        playerCol.color = playerBodyCol;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("playerKiller") == true)
        {
            Destroy(other);
            Destroy(this.gameObject);

            gameManagingScript.GameOverScreen();
        }
    }
}
