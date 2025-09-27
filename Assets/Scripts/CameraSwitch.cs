using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera endCam;

    // Start is called before the first frame update
    void Start()
    {
        endCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        startCam.enabled = false;
        endCam.enabled = true;
        CloudMovement.gameOn = true;
    }
}
