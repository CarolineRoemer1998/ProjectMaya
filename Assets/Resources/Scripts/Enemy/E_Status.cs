using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Status : MonoBehaviour
{
    [SerializeField] private int HpBase = 20;
    [SerializeField] private int HpMax = 20;
    [SerializeField] private int HpCurrent = 20;
    [SerializeField] private int EnemySpeed = 4;
    [SerializeField] private int ApBase = 5; 
    [SerializeField] private int ApCurrent = 5;
    [SerializeField] private int Knockback = 250;

    public E_Status()
    {
        HpCurrent = HpMax;
    }
    private void Update()
    {
        //Vielleicht in eigenes Skipt auslagern?
        Checkhealth();
    }
    /// <summary>
    /// Checkt ob ein Gegner 0 oder weniger Leben hat, wenn wir er zerstört
    /// </summary>
    private void Checkhealth()
    {
        if (HpCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        HpCurrent -= damage;
    }

    //Getter und Setter
    public int getEnemySpeed()
    {
        return EnemySpeed;
    }

    public int getEnemyHp()
    {
        return HpCurrent;
    }

    public int getDamage()
    {
        return ApCurrent;
    }
    public int getKnockback()
    {
        return Knockback;
    }
}
