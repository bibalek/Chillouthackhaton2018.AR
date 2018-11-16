using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ARVRScenesTransition : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ActivateVR());
    }

    IEnumerator ActivateVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        yield return null;
        XRSettings.enabled = true;
    }

}
