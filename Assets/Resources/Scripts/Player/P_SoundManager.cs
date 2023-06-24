using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource stepSounds;
    [SerializeField] private AudioSource swing;
    [SerializeField] private AudioSource[] punches;
    [SerializeField] private AudioSource[] kills;


    private void Update()
    {
        PlaySteps();
    }

    //public void PlaySound(bool swinging, bool punching, bool killing)
    //{
    //    PlaySwing(swinging);
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

    //private void PlaySwing(bool swinging)
    //{
    //    if (Input.GetMouseButtonDown(0) && swinging)
    //    {
    //        swing.enabled = true;
    //        Debug.Log(swing.enabled);
    //        swing.Play();
    //        swing.enabled = false;
    //        Debug.Log(swing.enabled);
    //    }

    //    sSwinging = false;
    //}

    //private void PlayPunch(bool punching)
    //{
    //    if (Input.GetMouseButtonDown(0) && punching)
    //    {
    //        System.Random rnd = new System.Random();
    //        punches[rnd.Next(1, 4)].Play();
            
    //        sPunching = false;
    //    }
    //}

    //private void PlayKill(bool killing)
    //{
    //    if (Input.GetMouseButtonDown(0) && killing)

    //        if (Input.GetMouseButtonDown(0) && sPunching)
    //        {
    //            System.Random rnd = new System.Random();
    //            kills[rnd.Next(1, 4)].Play();

    //            sKilling = false;
    //        }
    //}
}
