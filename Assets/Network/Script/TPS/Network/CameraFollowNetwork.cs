using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNetwork : MonoBehaviour
{
    private CinemachineFreeLook cinemachineFreeLook;
    private void Awake()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    public void FollowPlayer(Transform transform) 
    {
        cinemachineFreeLook.Follow = transform;
    }
}
