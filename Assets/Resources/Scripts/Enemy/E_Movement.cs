using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Enemy
/// </summary>
public class E_Movement : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private bool hasPatrol;
    [SerializeField] private List<GameObject> patrolPoints;
    private Rigidbody2D playerRB;
    private Rigidbody2D rb;
    private Rigidbody2D pointRB;
    private E_Status status;
    private Vector3 direction;
    private Vector2 movement;
    /// <summary>
    /// Speichert ob der Spieler aktuell im Detection-Radius ist
    /// </summary>
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<E_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            SimpleEnemyMovement();
        }
        if (hasPatrol)
        {
            MoveToPoint();
            NextPoint();
        }
        Animations();
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
    private void Animations()
    {
        //TODO
    }

    //Patrol System
    //Jeder Punkt der abgelaufen werden soll, muss als PatrolFlag dem Gegner hinzugefügt werden
    private void MoveToPoint()
    {
        pointRB = patrolPoints[0].GetComponent<Rigidbody2D>();
        direction = pointRB.transform.position - rb.transform.position;
        direction.Normalize();
        movement = direction;
        if (!active)
        {
            rb.MovePosition((Vector2)rb.transform.position + (movement * status.getEnemySpeed() / 100));
        }
    }

    private void NextPoint()
    {
        if (Vector3.Distance(rb.transform.position, pointRB.transform.position) < 0.1f)
        {
            GameObject temp = patrolPoints[0];
            patrolPoints.RemoveAt(0);
            patrolPoints.Add(temp);
        }
    }

    public Vector2 getTarget()
    {
        if (active)
        {
            return playerRB.transform.position;
        }
        else
        {
            return patrolPoints[0].GetComponent<Rigidbody2D>().transform.position;
        }
    }
}
