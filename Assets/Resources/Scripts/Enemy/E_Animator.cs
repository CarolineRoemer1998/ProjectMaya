using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Animator : MonoBehaviour
{
    Animator animator;
    private string currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;

        animator.Play(newState);

        currentState = newState;
    }
}
