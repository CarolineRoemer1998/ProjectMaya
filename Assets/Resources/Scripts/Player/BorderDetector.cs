using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sorgt dafür, dass sich Türen schließen, sobald der Spieler eine bestimmte Grenze überschreitet
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
