using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TimeChanger : MonoBehaviour
{
    private Transform tf;
    [SerializeField] private CinemachineBrain brain;
    [SerializeField] private float maxCooldown;
    private string timeState;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        timeState = "past";
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            TimeChange();
        }
        else if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Wechselt bei input zwischen 2 "Zeiten" indem der Spieler teleportiert wird
    /// </summary>
    void TimeChange()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            cooldown = maxCooldown;
            brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            if ( timeState == "past")
            {
                tf.position = new Vector3(tf.position.x, tf.position.y - 18, tf.position.z);
                timeState = "future";
            }
            else if(timeState == "future")
            {
                tf.position = new Vector3(tf.position.x, tf.position.y + 18, tf.position.z);
                timeState = "past";
            }
            //Nötig damit die Kamera nicht im gleichen tick zurück gestellt wird
            Invoke("ChangeBack", 0.1f);
        }
    }

    void ChangeBack()
    {
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.HardOut;
    }
}
