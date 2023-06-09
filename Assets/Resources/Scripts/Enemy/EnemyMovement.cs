using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private bool active;
    [SerializeField] GameObject player;
    private Rigidbody2D playerRB;
    private Rigidbody2D rb;
    private EnemyStatus status;
    private Vector3 direction;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            SimpleEnemyMovement();
        }
    }
    private void SimpleEnemyMovement()
    {
        direction = playerRB.transform.position - rb.transform.position;
        direction.Normalize();
        movement = direction;
        rb.MovePosition((Vector2)transform.position + (movement * status.getEnemySpeed()/100));
    }

    public bool getActive()
    {
        return active;
    }
    public void setActive(bool active)
    {
        this.active = active;
    }

}
