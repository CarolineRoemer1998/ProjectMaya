using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    [SerializeField] private PlayerStatus Parentstatus;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Hit thing");
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player hit Enemy");
            //Parentstatus.TakeDamage(other.GetComponent<EnemyStatus>().getDamage());
        }
    }
}
