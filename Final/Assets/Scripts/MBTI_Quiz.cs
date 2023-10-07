using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class MBTI_Quiz : MonoBehaviour
{

    public TextMeshProUGUI QuestionHeader;
    public TextMeshProUGUI Ans1;
    public TextMeshProUGUI Ans2;
    public TextMeshProUGUI Ans3;
    public int questionNumber = -1;

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

    MBTIQuestionsList loadedData;
    public Question[] listQuestions;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
        string filePath = Path.Combine(Application.dataPath, "Scripts/MBTIData.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedData = JsonUtility.FromJson<MBTIQuestionsList>(dataAsJson);
            listQuestions = loadedData.questions;
            NextQuestion();

        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }


  public  int E = 0;
    public int I = 0;

    public int S = 0;
    public int N = 0;

    public int T = 0;
    public int F = 0;

    public int J = 0;
    public int P = 0;
    public void Agree()
    {
        var question = listQuestions[questionNumber];
        switch (question.type)
        {
            case "Extraversion/Introversion":
                E += 1;
                break;
            case "Sensing/Intuition":
                S += 1;
                break;
            case "Thinking/Feeling":
                T += 1;
                break;
            case "Judging/Perceiving":
                J += 1;
                break;
        }
        if (questionNumber > listQuestions.Length)
        {

            return;
        }
        NextQuestion();
    }
    public void Disagree()
    {
        var question = listQuestions[questionNumber];
        
        switch (question.type)
        {
            case "Extraversion/Introversion":
                I += 1;
                break;
            case "Sensing/Intuition":
                N += 1;
                break;
            case "Thinking/Feeling":
                F += 1;
                break;
            case "Judging/Perceiving":
                P += 1;
                break;
        }
        if (questionNumber > listQuestions.Length)
        {

            return;
        }
        NextQuestion();
    }
    public string Finish()
    {
        string result = "";
        result += (E > I) ? "E" : "I";
        result += (S > N) ? "S" : "N";
        result += (T > F) ? "T" : "F";
        result += (J > P) ? "J" : "P";
        return result;
    }
    public void NextQuestion()
    {
        Debug.Log(questionNumber);
        if (questionNumber + 1 >= listQuestions.Length)
        {
            QuestionHeader.text = Finish();
            return;
        }
        questionNumber += 1;
       
        // Example of accessing the data
        //foreach (var question in loadedData.questions)
        //{
        //    QuestionHeader.text = question.text;
        //    Debug.Log("Question ID: " + question.question_id);
        //    Debug.Log("Text: " + question.text);
        //}
        QuestionHeader.text = loadedData.questions[questionNumber].text;
        Ans1.text = listQuestions[questionNumber].responses[0].text;
        Ans2.text = listQuestions[questionNumber].responses[1].text;
        Ans3.text = listQuestions[questionNumber].responses[2].text;
        
        



    }
    public void Neutral()
    {
        E += 0;
        S += 0;
        T += 0;
        J += 0;
        I += 0;
        N += 0;
        F += 0;
        P += 0;
        if (questionNumber > listQuestions.Length)
        {

            return;
        }
        NextQuestion();
    }
}