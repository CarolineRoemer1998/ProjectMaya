using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Status : MonoBehaviour
{
    [SerializeField] private int HpBase;
    [SerializeField] private int HpMax;
    [SerializeField] private int HpCurrent;
    [SerializeField] private int PlayerSpeed;
    [SerializeField] private int ApBase;
    [SerializeField] private int ApCurrent;

    public P_Status()
    {
        HpCurrent = HpMax;
    }

    public void Heal(int hp)
    {
        if (HpCurrent + hp <= HpMax)
        {
            HpCurrent += hp;
        }
        else
        {
            HpCurrent = HpMax;
        }
    }

    public void TakeDamage(int damage)
    {
        HpCurrent -= damage;
    }

    /// <summary>
    /// Aufrufen wenn Item aufgehoben oder gedroppt wird
    /// </summary>
    //public void SetAp()
    //{
    // TODO: Inventar einrichten - aktuelle Items lesen und daraus Ap berechnen
    //}

    /// <summary>
    /// Aufrufen wenn Item aufgehoben oder gedroppt wird
    /// </summary>
    //public void SetSpeed()
    //{
    // TODO: Inventar einrichten - aktuelle Items lesen und daraus Speed berechnen
    //}

    /// <summary>
    /// Aufrufen wenn Item aufgehoben oder gedroppt wird
    /// </summary>
    //public void SetMaxHP()
    //{
    // TODO: Inventar einrichten - aktuelle Items lesen und daraus MaxHP berechnen
    //}

    //Getter 
    public int getPlayerSpeed()
    {
        return PlayerSpeed;
    }
    public int getPlayerHp()
    {
        return HpCurrent;
    }
    public int getDamage()
    {
        return ApCurrent;
    }
}
