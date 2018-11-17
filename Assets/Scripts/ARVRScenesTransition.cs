using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ARVRScenesTransition : MonoBehaviour
{
    public static bool isVr;

    void Start()
    {
        if (isVr)
            StartCoroutine(ActivateVR());
        else
        {
            Camera.main.GetComponent<NoVrCameraMovement>().enabled = true;
        }

    }

    IEnumerator ActivateVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        yield return null;
        XRSettings.enabled = true;
    }
}
