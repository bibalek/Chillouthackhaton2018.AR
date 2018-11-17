using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private ApplicationController applicationController;

    [SerializeField]
    private Text loginResult;


    public void Login()
    {
        loginResult.text = applicationController.Login() ? "Login Success" : "Login failed";
    }
    
}
