using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{
    public ApiClient apiClient;
    public Text debugText;
    public async void Start()
    {
        apiClient.Test();
    }
}
