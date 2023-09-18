using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class APICall : MonoBehaviour
{
    // Start is called before the first frame update
    public class Fact
    {
       public string fact {  get;  set; }
       public string lenght { get; set; }
    }
    public class User
    {
        public string FirstName { get; set; }
    }

    public TextMeshProUGUI text;
    public TextMeshProUGUI textUser;

    private void Start()
    {
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
        StartCoroutine(GetRequestUser("https://localhost:7173/WeatherForecast"));
    }
    public void OnRefresh()
    {
        Start();
    }

    IEnumerator GetRequest(string uri)
    {
        using(UnityWebRequest webRequest= UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
            
                    break;
                case UnityWebRequest.Result.Success:
                    Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                    text.text = fact.fact;  
                    break;
                    
            }
        }
    }
    IEnumerator GetRequestUser(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));

                    break;
                case UnityWebRequest.Result.Success:
                    User user = JsonConvert.DeserializeObject<User>(webRequest.downloadHandler.text);
                    textUser.text = user.FirstName;
                    break;

            }
        }
    }
}
