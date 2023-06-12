using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : MonoBehaviour
{
    private P_Status playerStatus;
    private float damageTick;
    private bool hit;
    private Collider2D player;
    private int enemyDamage;
    private int enemyKnockback;

    //Nötig damit der Spieler als flüssige bewegung vom Gegner weggeschlagen wird und nicht in einem stück teleportiert wird
    /// <summary>
    /// Alle 10 Updates wird der spieler nach einem treffer zurück geschlagen, der couter zahlt dies.
    /// </summary>
    private int counter;
    /// <summary>
    /// Anzahl wie of der Spieler nach einem treffer zurück geschlagen wird.
    /// </summary>
    private int times;

    void Start()
    {
        hit = false;
        damageTick = 1;
        counter = 0;
        times = 0;
        enemyDamage = gameObject.GetComponentInParent<E_Status>().getDamage();
        enemyKnockback = gameObject.GetComponentInParent<E_Status>().getKnockback();
    }

    void Update()
    {
        damageTick += Time.deltaTime;
        if (hit)
        {
            if (damageTick >= 1f)
            {
                damageTick = 0;
                playerStatus.TakeDamage(enemyDamage);
                Debug.Log(playerStatus.getPlayerHp());
                times = 8;
            }
        }
        //Wenn times > 0 soll der counter resettet werden damit der spieler ein weiteres mal zurück gestoßen wird
        if (times > 0 && counter == 0)
        {
            times -= 1;
            counter = 10;
        }
        //Wenn counter 0 wird der spieler zurück geworfen
        if (playerStatus != null)
        {
            if (counter == 10) { Knockback(playerStatus.gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponentInParent<Rigidbody2D>().transform, enemyKnockback); }
            if (counter > 0) { counter -= 1; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other;
            hit = true;
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
    private void Knockback(Rigidbody2D player, Transform enemy, int force)
    {
        Vector2 knockback = (enemy.position - player.transform.position);
        knockback.Normalize();
        player.AddForce((Vector2)player.transform.position - (knockback * force));
    }
}
