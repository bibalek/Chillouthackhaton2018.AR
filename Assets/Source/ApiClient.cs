using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using Assets.Source.Extension;
using System.IO;
using RestSharp;

public class ApiClient : MonoBehaviour
{
    //private HttpClient client = new HttpClient();
    public TestController testController;


    private void Awake()
    {
        //Initialize();
    }

    private RestClient restClient = new RestClient("http://10.4.0.111/hackathon/api/");

    public void Test()
    {
        //try
        //{
        var request = new RestRequest("values/", Method.GET);

        var response = restClient.Execute(request);

        var s = response.Content;
        testController.debugText.text = s;
        //HttpResponseMessage response = await client.GetAsync("values/");

        //if (response.IsSuccessStatusCode)
        //{
        //    await DoSth(response);
        //    return true;
        //}
        //else
        //{
        //    //debugtext.text = response.statuscode.tostring();
        //    return false;
        //}
        //}
        //catch (Exception e)
        //{
        //    return false;
        //}
    }

    //public async Task<bool> Login()
    //{
    //    try
    //    {
    //        LoginForm loginForm = new LoginForm { username = "user", password = "pass" };
    //        HttpResponseMessage response = await client.PostAsUnityJsonAsync("testendpoint", loginForm);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            await DoSth(response);
    //            return true;
    //        }
    //        else
    //        {
    //            //debugtext.text = response.statuscode.tostring();
    //            return false;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        return false;
    //    }
    //}

    //private async Task DoSth(HttpResponseMessage response)
    //{
    //    //Stream receiveStream = response.GetResponseStream();
    //    //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
    //    //txtBlock.Text = readStream.ReadToEnd();
    //    testController.debugText.text = await response.Content.ReadAsStringAsync();
    //    int x = 10;
    //}

    //private void Initialize()
    //{
    //    client.BaseAddress = new Uri("http://10.4.0.111/hackathon/api/");
    //    //client.DefaultRequestHeaders.Accept.Add(
    //    //    new MediaTypeWithQualityHeaderValue("application/json"));
    //}

    //public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //{
    //    bool isOk = true;
    //    // If there are errors in the certificate chain, look at each error to determine the cause.
    //    if (sslPolicyErrors != SslPolicyErrors.None)
    //    {
    //        for (int i = 0; i < chain.ChainStatus.Length; i++)
    //        {
    //            if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
    //            {
    //                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
    //                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
    //                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
    //                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
    //                bool chainIsValid = chain.Build((X509Certificate2)certificate);
    //                if (!chainIsValid)
    //                {
    //                    isOk = false;
    //                }
    //            }
    //        }
    //    }
    //    return isOk;
    //}
}

public class LoginForm
{
    public string username;
    public string password;
    public string token;
}

