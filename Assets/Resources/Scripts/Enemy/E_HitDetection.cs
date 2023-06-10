using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_HitDetection : MonoBehaviour
{
    private E_Status status;
    private float damageTick;
    private bool hit;
    private Collider2D other;

    private void Start()
    {
        status = gameObject.GetComponent<E_Status>();
        hit = false;
        damageTick = 1;
    }

    private void Update()
    {
        damageTick += Time.deltaTime;
        if (hit && Input.GetMouseButtonDown(0))
        {
            if (damageTick >= 1f )
            {
                damageTick = 0;
                status.TakeDamage(other.GetComponentInParent<P_Status>().getDamage());
                Debug.Log(status.getEnemyHp());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            this.other = other;
            hit = true;
            Debug.Log("Enemy ís hit");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            hit = false;
            Debug.Log("Enemy is not hit");
        }
    }
}
