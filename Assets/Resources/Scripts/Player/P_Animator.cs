using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Animator : MonoBehaviour
{
    private Animator animator;
    private string currentState;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;

        if(newState=="attack_up" || newState == "attack_down" || newState == "attack_left" || newState == "attack_right")
        {
            animator.Play(newState);
            return;
        }

        animator.Play(newState);

        currentState = newState;
    }
}
