using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static APICall;
using UnityEngine.Networking;

public class TamNguLon : MonoBehaviour
{
    public string jwtToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9" +
        ".eyJuYW1lIjoibWluaHF1YW4iLCJSb2xlIjoiU3R1ZGVudCIsIlVzZXJJZCI6IjkwOWYwM2EyLTA1YzgtNGI5Ny1mNTU2LTA4ZGJjMDlmMTQ2NCIsImV4" +
        "cCI6MTY5NjgyMjEyN30.bVkMU3y6QZ2HJGkEPPNtsqUQyX-9P-USfs4TpAEwhhY5icLj_E8Y9tR4igxVUUUani5eYYtfgYAakmtt7nu8Vg";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://localhost:7145/WeatherForecast"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));

                    break;
                case UnityWebRequest.Result.Success:
                    Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text);
                    Fact fact1 = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text);
                    /*  Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text.ToString());*/
                    break;

            }
        }
    }
    public void TamNgu()
    {
        Debug.Log("Tam ngu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
