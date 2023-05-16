using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int HpBase;
    public int HpMax;
    public int HpCurrent;
    public int playerSpeed;
    public int ApBase;
    public int ApCurrent;

    public Status()
    {
        HpCurrent = HpMax;
    }

    public int getPlayerSpeed()
    {
        return this.playerSpeed;
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
}
