using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionScene3 : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            CinemachineVirtualCamera vcam = GameObject.Find("Follow Camera").GetComponent<CinemachineVirtualCamera>();
            CinemachineFramingTransposer transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_ScreenY = 0.25f;
        }
    }
}
