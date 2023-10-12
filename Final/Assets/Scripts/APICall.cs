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
    public TextMeshProUGUI Ans1;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
        StartCoroutine(GetRequestExam("https://localhost:7145/api/Examinations/617045c1-0cfb-4df6-6215-08dbc344fd3c"));
    }
    public void OnRefresh()
    {
        Start();

    }

    IEnumerator GetRequest(string uri)
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
                    Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text);
                    /*  Fact fact = JsonUtility.FromJson<Fact>(webRequest.downloadHandler.text.ToString());*/
                    text.text = fact.fact;
                    break;
            }
        }
    }

    [Serializable]
    public class Response
    {
        public int statusCode;
        public bool isSuccess;
        public string errorMessage;
        public Result result;
    }

    [Serializable]
    public class Result
    {
        public string name;
        public string description;
        public int totalNumberOfQuestion;
        public List<ExaminationQuestion> examinationQuestions;
    }

    [Serializable]
    public class ExaminationQuestion
    {
        public Question question;
    }

    [Serializable]
    public class Question
    {
        public string id; // This is kept as string for simplicity, but you can parse it to Guid later if needed.
        public string content;
    }


    [Serializable]
    public class QuestionContent1
    {
        public string QuestionContent;
        public List<string> Answers;
        public string CorrectAnswer;
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
                    var content = response.result.examinationQuestions[0].question.content.ToString();


                    QuestionContent1 question = JsonUtility.FromJson<QuestionContent1>(content);
                    textUser.text = question.QuestionContent.ToString();
                    Ans1.text = question.Answers[0].ToString();

                    break;

            }
        }
    }
}
