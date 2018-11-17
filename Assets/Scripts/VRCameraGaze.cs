using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraGaze : MonoBehaviour
{

    public Camera viewCamera;
    bool isGazing;

    private void Start()
    {
        viewCamera = Camera.main;
        isGazing = false;
    }

    void Update()
    {
        // Create a gaze ray pointing forward from the camera
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "teleport")
            {
                isGazing = true;
            }
        }
        else
        {
            isGazing = false;
        }
    }
}
