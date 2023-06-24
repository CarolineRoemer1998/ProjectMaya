using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSteps : MonoBehaviour
{
    [SerializeField] private AudioSource stepSounds;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            stepSounds.enabled = true;
        else
            stepSounds.enabled = false;
    }
}
