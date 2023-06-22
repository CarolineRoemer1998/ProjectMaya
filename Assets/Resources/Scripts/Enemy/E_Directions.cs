using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Part of the Enemy, Erkennt in welche richtung der Gegner gerade läuft
/// </summary>
public class E_Directions : MonoBehaviour
{
    private Rigidbody2D rb;
    private E_Animator animator;
    private float angle;
    private Vector2 pos_old;
    private int i;
    private string currentDirection;

    void Start()
    {
        animator = gameObject.GetComponent<E_Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos_old = rb.position;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Direction_Detection();
        i++;
    }
    private void Direction_Detection()
    {
        Vector2 pos = rb.transform.position;
        Vector2 target = gameObject.GetComponent<E_Movement>().getTarget();
        Vector2 temp = target - pos;
        angle = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle = 360 + angle;
        }
        Animations(angle);
    }
    private void Animations(float angle)
    {
        //Oben
        if(45f < angle && angle < 135f)
        {
            if (currentDirection != "Up")
            {
                animator.ChangeAnimationState("E_Move_Up");
                currentDirection = "Up";
                Debug.Log("Up");
            }
        }
        //Unten
        else if (225f < angle && angle < 315f)
        {
            if (currentDirection != "Down")
            {
                animator.ChangeAnimationState("E_Move_Down");
                currentDirection = "Down";
                Debug.Log("Down");
            }
        }
        //Links
        else if (135f <= angle && angle <= 225f)
        {
            if (currentDirection != "Left")
            {
                animator.ChangeAnimationState("E_Move_Left");
                currentDirection = "Left";
                Debug.Log("Left");
            }
        }
        //Rechts
        else if ((315f <= angle && angle <= 360f)||(0f <= angle && angle <= 45f))
        {
            if (currentDirection != "Right")
            {
                animator.ChangeAnimationState("E_Move_Right");
                currentDirection = "Right";
                Debug.Log("Right");
            }
        }
    }

    public string GetDirection()
    {
        return currentDirection;
    }
}
