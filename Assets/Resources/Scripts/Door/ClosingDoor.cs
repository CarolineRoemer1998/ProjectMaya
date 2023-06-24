using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoor : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Vector2 startPos;
    private Vector2 endPos=new Vector2(-0.56f,5.8f);
    private bool closing = false;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if(closing)
            CloseDoor(endPos);
    }

    void CloseDoor(Vector2 goalPos)
    {
        float dist = Vector2.Distance(transform.position, goalPos);
        if(dist > 0f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, goalPos, speed * Time.deltaTime);
        }
        else
        {
            closing = false;
        }
    }

    public bool Closing
    {
        get { return closing; }
        set { closing = value; }
    }
}
