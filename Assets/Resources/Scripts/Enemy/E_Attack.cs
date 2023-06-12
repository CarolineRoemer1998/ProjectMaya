using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : MonoBehaviour
{

    private P_Status playerStatus;
    private float damageTick;
    private bool hit;
    private Collider2D player;

    void Start()
    {
        hit = false;
        damageTick = 1;
    }

    // Update is called once per frame
    void Update()
    {
        damageTick += Time.deltaTime;
        if (hit)
        {
            if (damageTick >= 1f)
            {
                damageTick = 0;
                playerStatus.TakeDamage(gameObject.GetComponentInParent<E_Status>().getDamage());
                Debug.Log(playerStatus.getPlayerHp());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in hit range");
            player = other;
            hit = true;
            //Get Player Status
            playerStatus = player.gameObject.GetComponentInParent<P_Status>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hit = false;
        }
    }
}
