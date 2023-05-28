using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }


    /// <summary>
    /// Switch auf die ausgewählte Camera und setzt die Prio aller anderen auf 0
    /// </summary>
    /// <param name="camera"></param>
    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera)
            {
                c.Priority = 0;
            }
        }
    }
    
    /// <summary>
    /// Registriert die Camera im CameraSwitcher um sie später wechseln zu können.
    /// </summary>
    /// <param name="camera"></param>
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    /// <summary>
    /// Entfernt die Camera aus dem CameraSwitcher.
    /// </summary>
    /// <param name="camera"></param>
    public static void UnRegister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }


}
