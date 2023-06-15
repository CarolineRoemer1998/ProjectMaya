using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Enemy-Attack-Radius
/// </summary>
public class E_Attack : MonoBehaviour
{
    private P_Status playerStatus;
    private float damageTick;
    private bool hit;
    private Collider2D player;
    private int enemyDamage;
    private int enemyKnockback;

    //N�tig damit der Spieler als fl�ssige bewegung vom Gegner weggeschlagen wird und nicht in einem st�ck teleportiert wird
    /// <summary>
    /// Alle x sekunden wird der gegner nach einem treffer zur�ck geschlagen, der timer zahlt dies.
    /// </summary>
    private float timer;
    /// <summary>
    /// Anzahl wie of der Gegner nach einem treffer zur�ck geschlagen wird.
    /// </summary>
    private int counter;

    void Start()
    {
        hit = false;
        damageTick = 1;
        timer = 0;
        counter = 0;
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
                counter = 10;
            }
        }
        //Wenn counter > 0 soll der counter resettet werden damit der spieler ein weiteres mal zur�ck gesto�en wird
        if (counter > 0 && timer <= 0)
        {
            counter -= 1;
            timer = 0.01f;
        }
        //Wenn timer 0.01 ist, wird der spieler zur�ck geworfen
        if (playerStatus != null)
        {
            if (timer == 0.01f)  { Knockback(playerStatus.gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponentInParent<Rigidbody2D>().transform, enemyKnockback); }
            if (timer > 0.0f) { timer -= Time.deltaTime; }
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
    /// Methode damit der Spieler bei treffer eines Gegners zur�ck gesto�en wird
    /// </summary>
    private void Knockback(Rigidbody2D player, Transform enemy, int force)
    {
        Vector2 knockback = (enemy.position - player.transform.position);
        knockback.Normalize();
        player.AddForce((Vector2)player.transform.position - (knockback * force));
    }
}
