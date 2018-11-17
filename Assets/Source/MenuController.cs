using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private ApplicationController applicationController;
    [SerializeField]
    private GameObject loginPanel;
    [SerializeField]
    private GameObject modePanel;

    [SerializeField]
    private Text loginResult;

    private void Start()
    {
        if(applicationController.userLogged)
        {
            loginPanel.SetActive(false);
            modePanel.SetActive(true);
        }
    }

    public async void Login()
    {
        if(applicationController == null)
        {
            applicationController = FindObjectOfType<ApplicationController>();
        }
        //loginResult.text = applicationController.Login() ? "Login Success" : "Login failed";
        applicationController.userLogged =  await applicationController.Login();
        applicationController.GetCurrentMarkers();
    }
    
    public void GetMarkersFromDatabase()
    {
        ApplicationController.Instance.GetCurrentMarkers();
    }

    public void SetCurrentModels()
    {
        ApplicationController.Instance.SetCurrentModels();
    }

    public void UpdateMarkerModel()
    {
        ApplicationController.Instance.UpdateMarkerModel();
    }

}
