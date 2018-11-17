using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ARSceneUIManager : MonoBehaviour
{

    public void LoadVRScene()
    {
        ARObjectsSave save = FindObjectOfType<ARObjectsSave>();
        save.SaveAllARFurniture();
        SceneManager.LoadScene(1);
    }
}
