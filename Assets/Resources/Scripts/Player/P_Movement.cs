using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Player
/// </summary>
public class P_Movement : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private int playerSpeed;
    private Rigidbody2D rb;


    void Start()
    {
        playerSpeed = gameObject.GetComponent<P_Status>().getPlayerSpeed();
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

        if (Input.GetKey(KeyCode.W))
        {
            rb.rotation = 0f;
            //Animation flag
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.rotation = 180f;
            //Animation flag
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation = 270f;
            //Animation flag
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.rotation = 90f;
            //Animation flag
        }
    }
}
