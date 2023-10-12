using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.Networking;

public class MainScript : MonoBehaviour {

	private readonly string basePath = "https://jsonplaceholder.typicode.com";
	private RequestHelper currentRequest;

	private void LogMessage(string title, string message) {
#if UNITY_EDITOR
		EditorUtility.DisplayDialog (title, message, "Ok");
#else
		Debug.Log(message);
#endif
	}

	public void Get(){

		// We can add default request headers for all requests
		RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

		RequestHelper requestOptions = null;

		RestClient.GetArray<LoginRequest>(basePath + "/posts").Then(res => {
			this.LogMessage("Posts", JsonHelper.ArrayToJsonString<LoginRequest>(res, true));
			return RestClient.GetArray<Todo>(basePath + "/todos");
		}).Then(res => {
			this.LogMessage("Todos", JsonHelper.ArrayToJsonString<Todo>(res, true));
			return RestClient.GetArray<User>(basePath + "/users");
		}).Then(res => {
			this.LogMessage("Users", JsonHelper.ArrayToJsonString<User>(res, true));

			// We can add specific options and override default headers for a request
			requestOptions = new RequestHelper { 
				Uri = basePath + "/photos",
				Headers = new Dictionary<string, string> {
					{ "Authorization", "Other token..." }
				},
				EnableDebug = true
			};
			return RestClient.GetArray<Photo>(requestOptions);
		}).Then(res => {
			this.LogMessage("Header", requestOptions.GetHeader("Authorization"));

			// And later we can clear the default headers for all requests
			RestClient.ClearDefaultHeaders();

		}).Catch(err => this.LogMessage("Error", err.Message));
	}

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

    public void Post()
    {

        LoginData loginData = new LoginData
        {
            userName = "trinhtam",
            password = "trinhtam"
        };

        // Set the URL for your login API
        string url = "https://localhost:7145/api/Users/login";

        // Send a POST request with RestClient
        RestClient.Post<LoginResponse>(url, loginData).Then(response =>
        {
            // Check the response here
            Debug.Log("Login response: " + response.result);
        }).Catch(error =>
        {
            // Handle errors here
            Debug.LogError("Error: " + error.Message);
        });

        
    }

	

	

	public void AbortRequest(){
		if (currentRequest != null) {
			currentRequest.Abort();
			currentRequest = null;
		}
	}

	public void DownloadFile(){

		var fileUrl = "https://raw.githubusercontent.com/IonDen/ion.sound/master/sounds/bell_ring.ogg";
		var fileType = AudioType.OGGVORBIS;

		RestClient.Get(new RequestHelper {
			Uri = fileUrl,
			DownloadHandler = new DownloadHandlerAudioClip(fileUrl, fileType)
		}).Then(res => {
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = ((DownloadHandlerAudioClip)res.Request.downloadHandler).audioClip;
			audio.Play();
		}).Catch(err => {
			this.LogMessage("Error", err.Message);
		});
	}
}