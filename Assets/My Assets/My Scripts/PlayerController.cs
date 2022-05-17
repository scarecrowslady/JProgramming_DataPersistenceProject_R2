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
    public GameObject gameManager;

    //game UI stuff
    public GameObject mainGameUIPanel;
    public GameObject pauseGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = playerPFB.GetComponent<SpriteRenderer>();
        gameManagingScript = gameManager.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerColor();

        if(MainManager.Instance.isLevelEnded == false)
        {
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

        Debug.Log("Player Health: " + MainManager.Instance.PlayerHealth + "");
    }

    public void SetPlayerColor()
    {
        if (MainManager.Instance != null)
        {
            playerBodyCol = MainManager.Instance.PlayerColor;
            playerCol.color = playerBodyCol;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("playerKiller") == true)
        {
            gameManagingScript.GetComponent<GameController>().ManagePlayerHealth(-30);
        }

        if (other.CompareTag("res_rocks") || other.CompareTag("res_debris") || other.CompareTag("allienBullet") == true)
        {
            Debug.Log("I hit a resource");

            gameManagingScript.GetComponent<GameController>().ManagePlayerHealth(-2);
        }

        if (other.CompareTag("res_alien") || other.CompareTag("aggAlien") == true)
        {
            Debug.Log("I hit an alien");

            gameManagingScript.GetComponent<GameController>().ManagePlayerHealth(-4);
        }
    }
}
