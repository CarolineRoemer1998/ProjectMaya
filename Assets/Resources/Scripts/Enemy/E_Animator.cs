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

        if (newState == "E_Attack_Up" || newState == "E_Attack_Down" || newState == "E_Attack_Left" || newState == "E_Attack_Right")
        {
            animator.Play(newState);
            return;
        }

        animator.Play(newState);

        currentState = newState;
    }
}
