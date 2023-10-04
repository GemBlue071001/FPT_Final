using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class MBTI_Quiz : MonoBehaviour
{

    public TextMeshProUGUI QuestionHeader;
    public TextMeshProUGUI Ans1;
    public TextMeshProUGUI Ans2;

    [System.Serializable]
    public class Question
    {
        public int question_id;
        public string text;
        public string type;
        public Response[] responses;
    }

    [System.Serializable]
    public class Response
    {
        public string text;
        public int score;
    }

    [System.Serializable]
    public class MBTIQuestionsList
    {
        public Question[] questions;
    }

    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, "Scripts/MBTIData.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            MBTIQuestionsList loadedData = JsonUtility.FromJson<MBTIQuestionsList>(dataAsJson);

            // Example of accessing the data
            //foreach (var question in loadedData.questions)
            //{
            //    QuestionHeader.text = question.text;
            //    Debug.Log("Question ID: " + question.question_id);
            //    Debug.Log("Text: " + question.text);
            //}
            QuestionHeader.text = loadedData.questions[0].text;
            Ans1.text = loadedData.questions[0].responses[0].text;
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }
}
