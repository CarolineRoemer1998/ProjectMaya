using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int HpBase;
    [SerializeField] private int HpMax;
    [SerializeField] private int HpCurrent;
    [SerializeField] private int playerSpeed;
    [SerializeField] private int ApBase;
    [SerializeField] private int ApCurrent;

    public EnemyStatus()
    {
        HpCurrent = HpMax;
    }

    public int getEnemySpeed()
    {
        return this.playerSpeed;
    }

    public int getEnemyHp()
    {
        return this.HpCurrent;
    }

    public int getDamage()
    {
        return this.ApCurrent;
    }
}
