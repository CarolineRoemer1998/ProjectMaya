using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float inputX;
    private float inputY;

    private int playerSpeed;


    void Start()
    {
        playerSpeed = gameObject.GetComponent<Status>().getPlayerSpeed();
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

        movementSpeed = movementSpeed * Time.deltaTime;

        transform.Translate(movementSpeed);
    }
}
