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
    private P_Animator animator;

    void Start()
    {
        playerSpeed = gameObject.GetComponent<P_Status>().getPlayerSpeed();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<P_Animator>();
        animator.ChangeAnimationState("idle_down");
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
        //Sorgt daf�r, dass der movement speed immer konstant ist und nicht im vergleich zum restlichen spiel schneller wird wenn das spiel lagt. * 1000 um die geringe Zahl der deltaTime auszugleichen
        
        //Verbesserte Methode f�rs Movement, player wird nicht mehr teleportiert und somit in objekte hinein gesetzt, sondern nur bewegt
        rb.velocity = new Vector3(movementSpeed.x, movementSpeed.y);

        GetKeyActions();
        GetKeyUpActions();
        
    }

    private void GetKeyActions()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //rb.rotation = 0f;
            animator.ChangeAnimationState("move_up");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //rb.rotation = 180f;
            animator.ChangeAnimationState("move_down");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.rotation = 270f;
            animator.ChangeAnimationState("move_right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //rb.rotation = 90f;
            animator.ChangeAnimationState("move_left");
        }
    }

    private void GetKeyUpActions()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            //rb.rotation = 0f;
            animator.ChangeAnimationState("idle_up");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            //rb.rotation = 180f;
            animator.ChangeAnimationState("idle_down");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //rb.rotation = 270f;
            animator.ChangeAnimationState("idle_right");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            //rb.rotation = 90f;
            animator.ChangeAnimationState("idle_left");
        }
    }
}
