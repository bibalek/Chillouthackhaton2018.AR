using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    [SerializeField]
    private ApiClient apiClient;

    User user { get; set; }

    private void Awake()
    {
        user = new User(Const.loginUser, Const.loginPassword);
    }

    public bool Login()
    {
        user = apiClient.Login(user);
        if(user.FirstName == null && user.LastName == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
