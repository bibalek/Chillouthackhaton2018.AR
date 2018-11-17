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
using System.IO;
using RestSharp;
using Newtonsoft.Json;

public class ApiClient : MonoBehaviour
{
    public TestController testController;

    private RestClient restClient = new RestClient(Const.WebApi);

    public User Login(User currentUser)
    {
        var request = new RestRequest(Const.userLogin, Method.POST);
        request.AddJsonBody(currentUser);
        var response = restClient.Execute(request);
        var json = response.Content;
        return JsonConvert.DeserializeObject<User>(json);
    }

    public List<MarkerModel> GetMarkersByUserId(User currentUser)
    {
        var request = new RestRequest(Const.getMarkersByUserId, Method.GET);
        request.AddParameter("userId", currentUser.UserID, ParameterType.GetOrPost);
        var response = restClient.Execute(request);
        return JsonConvert.DeserializeObject<List<MarkerModel>>(response.Content);
    }
}


