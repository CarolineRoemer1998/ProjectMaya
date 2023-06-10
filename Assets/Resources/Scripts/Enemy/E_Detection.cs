using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check ob der Spieler im Trigger ist un wenn ja wird der Gegner Aktiviert
/// </summary>
public class E_Detection : MonoBehaviour
{

    [SerializeField] E_Movement movement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            movement.setActive(true);
            Debug.Log("Enemy detected Player");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            movement.setActive(false);
            Debug.Log("Enemy detected not Player");
        }
    }
}
