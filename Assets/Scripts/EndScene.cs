using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public ScreenTransition fadeScript;
    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera endCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(fadeScript.AnimateTransitionIn());
            StartCoroutine(SwitchCamDelay());
        }
    }

    IEnumerator SwitchCamDelay()
    {
        yield return new WaitForSeconds(1f);
        endCam.enabled = false;
        startCam.enabled = true;
    }
}
