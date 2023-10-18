using System.Collections;
using UnityEngine;
using Proyecto26;
using TMPro;

public class LoginScript : MonoBehaviour
{

    public TMP_InputField inputUserName;
    public TMP_InputField inputPassword;

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
            Debug.Log("Login response dit me m : " + response.result);
        }).Catch(error =>
        {
            // Handle errors here
            Debug.LogError("Error sai roi !!!!!!!!!!!: " + error.Message);
        });
    }


}
