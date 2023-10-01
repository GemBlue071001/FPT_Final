using System.Collections;
using UnityEngine;
using TMPro;
/*using Newtonsoft.Json;*/
using UnityEngine.Networking;
/*using Unity.Plastic.Newtonsoft.Json;*/

public class APICall : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Fact
    {
        public string fact;
        public string lenght;
    }
    public class User
    {
        public string FirstName { get; set; }
    }

    public TextMeshProUGUI text;
    public TextMeshProUGUI textUser;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
        /*StartCoroutine(GetRequestUser("https://localhost:7173/WeatherForecast"));*/
    }
    public void OnRefresh()
    {
        Start();
        Debug.Log("Ji");
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
                    Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text);
                  /*  Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text.ToString());*/
                    text.text = fact.fact;  
                    break;
                    
            }
        }
    }
   /* IEnumerator GetRequestUser(string uri)
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
                    //User user = JsonConvert.DeserializeObject<User>(webRequest.downloadHandler.text);
                    User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);
                    textUser.text = user.FirstName;
                    break;

            }
        }
    }*/
}
