using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int HpBase;
    [SerializeField] private int HpMax;
    [SerializeField] private int HpCurrent;
    [SerializeField] private int EnemySpeed;
    [SerializeField] private int ApBase;
    [SerializeField] private int ApCurrent;

    public EnemyStatus()
    {
        HpCurrent = HpMax;
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
}
