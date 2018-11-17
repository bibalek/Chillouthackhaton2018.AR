using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMarkersController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("in list there are: " + ApplicationController.Instance.markerModels.Count);
    }


}
