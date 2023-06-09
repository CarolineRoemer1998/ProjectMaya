using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private int playerSpeed;
    private Rigidbody2D rb;


    void Start()
    {
        playerSpeed = gameObject.GetComponent<PlayerStatus>().getPlayerSpeed();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        BasicMovement();
    }

    private void BasicMovement()
    {
        //Basic Movement Controller
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 movementSpeed = new Vector3(playerSpeed * inputX, playerSpeed * inputY);
        //Sorgt dafür, dass der movement speed immer konstant ist und nicht im vergleich zum restlichen spiel schneller wird wenn das spiel lagt. * 1000 um die geringe Zahl der deltaTime auszugleichen
        
        //Verbesserte Methode fürs Movement, player wird nicht mehr teleportiert und somit in objekte hinein gesetzt, sondern nur bewegt
        rb.velocity = new Vector3(movementSpeed.x, movementSpeed.y);

        if (inputY > 0)
        {
            rb.rotation = 0f;
        }
        else if (inputY < 0)
        {
            rb.rotation = 180f;
        }
        if (inputX > 0)
        {
            rb.rotation = 270f;
        }
        else if (inputX < 0)
        {
            rb.rotation = 90f;
        }
    }
}
