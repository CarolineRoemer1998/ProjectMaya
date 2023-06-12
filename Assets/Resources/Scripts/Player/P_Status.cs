using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Player
/// </summary>
public class P_Status : MonoBehaviour
{
    [SerializeField] private int HpBase = 20;
    [SerializeField] private int HpMax = 20;
    [SerializeField] private int HpCurrent = 20;
    [SerializeField] private int PlayerSpeed = 5;
    [SerializeField] private int ApBase = 5;
    [SerializeField] private int ApCurrent = 5;
    [SerializeField] private int Knockback = 250;

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

    //Getter und Setter
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
    public int getKnockback()
    {
        return Knockback;
    }
}
