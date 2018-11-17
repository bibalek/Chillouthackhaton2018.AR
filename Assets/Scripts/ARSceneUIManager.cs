using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace EasyAR
{

    public class ARSceneUIManager : MonoBehaviour
    {

        public void LoadVRScene(bool isVr)
        {
            ARVRScenesTransition.isVr = isVr;
            ARObjectsSave save = FindObjectOfType<ARObjectsSave>();
            save.SaveAllARFurniture();
            SceneManager.LoadScene(1);
        }
    }

}