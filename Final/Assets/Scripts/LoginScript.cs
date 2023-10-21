using System.Collections;
using UnityEngine;
using Proyecto26;
using TMPro;
using System.Collections.Generic;

public class LoginScript : MonoBehaviour
{

    public TMP_InputField inputUserName;
    public TMP_InputField inputPassword;
    public string token;

    [System.Serializable]
    public class LoginData
    {
        public string userName;
        public string password;
    }


    public class LoginResponse
    {
        public int statusCode;
        public bool isSuccess;
        public string errorMessage;
        public string result;
    }

    public void Login()
    {
        LoginData loginData = new LoginData
        {
            userName = inputUserName.text,
            password = inputPassword.text
        };

        // Set the URL for your login API
        string url = "https://localhost:7145/api/Users/login";

        // Send a POST request with RestClient
        RestClient.Post<LoginResponse>(new RequestHelper()
        {
            Uri = url,
            Body = loginData
        }).Then(response =>
        {
            // Check the response here
            Debug.Log("Login response: " + response.result);
            token = response.result;
        }).Catch(error =>
        {
            // Handle errors here
            Debug.LogError("Error:" + error.Message);
        });
    }

    [System.Serializable]
    public class SubjectRequest
    {
        public string Name;
        public string Description;
    }

    public void CreateSubject()
    {
        RestClient.Post<LoginResponse>(new RequestHelper()
        {
            Uri = "https://localhost:7145/api/Subjects",
            Body = new SubjectRequest
            {
                Name = "t chinh la trinh tam",
                Description = "ngoc thanh"
            },
            Headers = new Dictionary<string, string> {
             { "Authorization", $"Bearer {token}" }
            }
        }).Then(response =>
        {
            // Check the response here
            Debug.Log("Login response: " + response.isSuccess);
            token = response.result;
        }).Catch(error =>
        {
            // Handle errors here
            Debug.LogError("Error:" + error.Message.ToString());
        });
    }

}
