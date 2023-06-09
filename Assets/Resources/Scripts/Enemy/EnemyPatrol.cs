using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<GameObject> patrolPoints;
    private EnemyMovement move;
    private EnemyStatus status;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 direction;
    private Rigidbody2D pointRB;

    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<EnemyMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint(); 
        NextPoint();
    }

    private void MoveToPoint()
    {
        pointRB = patrolPoints[0].GetComponent<Rigidbody2D>();
        direction = pointRB.transform.position - rb.transform.position;
        direction.Normalize();
        movement = direction;
        if (!move.getActive())
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
}
