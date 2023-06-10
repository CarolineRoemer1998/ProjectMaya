using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Status : MonoBehaviour
{
    [SerializeField] private int HpBase;
    [SerializeField] private int HpMax;
    [SerializeField] private int HpCurrent;
    [SerializeField] private int EnemySpeed;
    [SerializeField] private int ApBase;
    [SerializeField] private int ApCurrent;

    private void Update()
    {
        //Vielleicht in eigenes Skipt auslagern?
        Checkhealth();
    }
    public E_Status()
    {
        HpCurrent = HpMax;
    }

    public void TakeDamage(int damage)
    {
        HpCurrent -= damage;
    }

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
}
