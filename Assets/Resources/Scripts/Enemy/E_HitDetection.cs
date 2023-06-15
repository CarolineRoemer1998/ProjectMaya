using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Enemy
/// </summary>
public class E_HitDetection : MonoBehaviour
{
    private E_Status status;
    private float damageTick;
    private bool hit;
    private Collider2D other;

    //N�tig damit der gegner als fl�ssige bewegung vom spieler weggeschlagen wird und nicht in einem st�ck teleportiert wird
    /// <summary>
    /// Alle x sekunden wird der gegner nach einem treffer zur�ck geschlagen, der timer zahlt dies.
    /// </summary>
    private float timer;
    /// <summary>
    /// Anzahl wie of der Gegner nach einem treffer zur�ck geschlagen wird.
    /// </summary>
    private int counter;

    private void Start()
    {
        status = gameObject.GetComponent<E_Status>();
        hit = false;
        damageTick = 1;
        timer = 0;
        counter = 0;
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
                counter = 10;

            }
        }
        //Wenn counter > 0 soll der timer resettet werden damit der gegner ein weiteres mal zur�ck gesto�en wird
        if (counter > 0 && timer <= 0)
        {
            counter -= 1;
            timer = 0.01f;
        }
        //Wenn timer 0.01 ist, wird der spieler zur�ck geworfen
        if (timer == 0.01f) { Knockback(other.gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponentInParent<Rigidbody2D>(), other.GetComponentInParent<P_Status>().getKnockback()); }
        if (timer > 0.0f) {timer -= Time.deltaTime;}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            this.other = other;
            hit = true;
            //Debug.Log("Enemy �s hit");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            hit = false;
            //Debug.Log("Enemy is not hit");
        }
    }
    private void Knockback(Rigidbody2D player, Rigidbody2D enemy, int force)
    {
        Vector2 knockback = (player.transform.position - enemy.transform.position);
        knockback.Normalize();
        Debug.Log("Test");
        enemy.AddForce((Vector2)enemy.transform.position - (knockback * force));
    }
}
