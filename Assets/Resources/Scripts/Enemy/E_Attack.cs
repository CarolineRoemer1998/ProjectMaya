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
                Knockback(playerStatus.gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponentInParent<Rigidbody2D>().transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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

    /// <summary>
    /// Methode damit der Spieler bei treffer eines Gegners zurück gestoßen wird
    /// </summary>
    private void Knockback(Rigidbody2D player, Transform enemy)
    {
        Debug.Log("Knock");
        Vector2 knockback = (enemy.position - player.transform.position);
        knockback.Normalize();
        player.MovePosition((Vector2)player.transform.position - (knockback*0.5f));

    }
}
