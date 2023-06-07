using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Bei Collider wird auf die Camera der Zone gewechselt
        if (other.CompareTag("Player"))
        {
            if (CameraSwitcher.ActiveCamera != cam) {
                CameraSwitcher.SwitchCamera(cam);
            }
        }
    }
}
