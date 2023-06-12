using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Enemy, Erkennt in welche richtung der Gegner gerade läuft
/// </summary>
public class E_Directions : MonoBehaviour
{
    private Rigidbody2D rb;
    private float angle;
    private Vector2 pos_old;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos_old = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        Direction_Detection();
    }
    private void Direction_Detection()
    {
        angle = Vector2.Angle(rb.position, pos_old);
        pos_old = rb.position;
        Debug.Log(angle);
    }
}
