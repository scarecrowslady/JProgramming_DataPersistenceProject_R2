using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopOutScript : MonoBehaviour
{
    public bool isClickedOn;

    private void Start()
    {
        isClickedOn = false;
    }

    private void Update()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            rayHit.transform.localScale = new Vector3(3, 8, 0);
            isClickedOn = true;

            if(rayHit.collider.name == "seller_Barba")
            {
                if(gameObject.name == "seller_Xandar" || gameObject.name == "seller_MT-7023")
                {
                    Destroy(gameObject);
                }
            }

            if (rayHit.collider.name == "seller_Xandar")
            {
                if (gameObject.name == "seller_Barba" || gameObject.name == "seller_MT-7023")
                {
                    Destroy(gameObject);
                }
            }

            if (rayHit.collider.name == "seller_MT-7023")
            {
                if (gameObject.name == "seller_Xandar" || gameObject.name == "seller_Barba")
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("chara") == true)
        {
            gameObject.transform.localScale = new Vector3(3, 8, 0);
        }
    }

    private void OnMouseExit()
    {
        if (gameObject.CompareTag("chara") == true && isClickedOn == false)
        {
            gameObject.transform.localScale = new Vector3(2, 7, 0);
        }
    }
}
