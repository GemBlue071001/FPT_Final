using System.Collections;
using UnityEngine;
using TMPro;
/*using Newtonsoft.Json;*/
using UnityEngine.Networking;
using System.Collections.Generic;
using System;
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
        StartCoroutine(GetRequestExam("https://localhost:7145/api/Examinations/bdd7ef86-f920-4fde-9dda-08dbc28e7568"));
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
                    Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text);
                  /*  Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text.ToString());*/
                    text.text = fact.fact;  
                    break;
                    
            }
        }
    }

    [System.Serializable]
    public class Response
    {
        public int StatusCode;
        public bool IsSuccess;
        public string ErrorMessage;
        public Result Result;
    }
    [System.Serializable]
    public class Result
    {
        public string Name;
        public string Description;
        public int TotalNumberOfQuestion;
        public List<ExaminationQuestion> ExaminationQuestions;
    }
    [System.Serializable]

    public class ExaminationQuestion
    {
        public Question Question;
    }
    [System.Serializable]
    public class Question
    {
        public Guid Id;
        public string Content;
    }
    IEnumerator GetRequestExam(string uri)
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
                    Response response = JsonUtility.FromJson<Response>(webRequest.downloadHandler.text);
                    textUser.text = response.Result.ToString();
                    break;

            }
        }
    }
}
