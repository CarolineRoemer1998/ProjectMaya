using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sorgt daf�r, dass sich T�ren schlie�en, sobald der Spieler eine bestimmte Grenze �berschreitet
/// </summary>
public class BorderDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            if(other.GetComponentInParent<ClosingDoor>().Closing == false)
            {
                other.GetComponentInParent<ClosingDoor>().Closing = true;
            }
        }
    }
}
