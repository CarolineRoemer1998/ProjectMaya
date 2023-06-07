using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    [SerializeField] private PlayerStatus Parentstatus;
    private float damageTick;
    private bool hit;
    private Collider2D other;

    private void Start()
    {
        hit = false;
        damageTick = 1;
    }

    private void Update()
    {
        if (hit)
        {
            damageTick += Time.deltaTime;
            if (damageTick >= 1f)
            {
                damageTick = 0;
                Parentstatus.TakeDamage(other.GetComponent<EnemyStatus>().getDamage());
                Debug.Log(Parentstatus.getPlayerHp());

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Hit thing");
        if (other.CompareTag("Enemy"))
        {
            this.other = other;
            hit = true;
            Debug.Log("Player hit Enemy");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hit = false;
            Debug.Log("Player hit not Enemy");
        }
    }
}