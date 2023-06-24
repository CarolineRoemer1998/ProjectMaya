using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource stepSounds;
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip swing;
    [SerializeField] private AudioClip[] punches;
    [SerializeField] private AudioClip[] kills;



    private void Update()
    {
        PlaySteps();
    }

    //public void PlaySound(bool swinging, bool punching, bool killing)
    //{
    //    PlayPunch(punching);
    //    PlayKill(killing);
    //}

    private void PlaySteps()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            stepSounds.enabled = true;
        else
            stepSounds.enabled = false;
    }

    public void PlaySwing()
    {
        src.clip = swing;
        src.Play();
    }

    public void PlayPunch()
    {
        System.Random rnd = new System.Random();
        src.clip = punches[rnd.Next(1, 4)];
        src.Play();
    }

    public void PlayKill()
    {
        System.Random rnd = new System.Random();
        src.clip = kills[rnd.Next(1, 4)];
        src.Play();
    }
}
