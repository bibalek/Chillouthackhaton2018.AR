using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public long? UserID { get; set; } 
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string userName, string pass)
    {
        UserName = userName;
        Password = pass;
    }
}

