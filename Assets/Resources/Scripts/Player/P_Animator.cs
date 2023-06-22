using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Animator : MonoBehaviour
{
    Animator animator;
    private string currentState;

    // Animation States
    const string ATTACK_DOWN = "attack_down";
    const string ATTACK_LEFT = "attack_left";
    const string ATTACK_UP = "attack_up";
    const string ATTACK_RIGHT = "attack_right";
    const string IDLE_LEFT = "idle_left";
    const string IDLE_UP = "idle_up";
    const string IDLE_RIGHT = "idle_right";

    // Start is called before the first frame update
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
