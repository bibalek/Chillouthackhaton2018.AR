using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVrCameraMovement : MonoBehaviour
{

    Quaternion origin = Quaternion.identity;

    private void Start()
    {
        Input.gyro.enabled = true;
        origin = Input.gyro.attitude;
    }

    void Update()
    {
        transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
    }
}
