using TMPro;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI quesTxt;
    public AnswerButton A;
    public AnswerButton B;
    public AnswerButton C;
    public QuestionController quesController;
    public GameObject  UI_Input;
    public GameObject victoryPanel;

    int group = 0;
    public void DisplayQuestion(Question ques)
    {
        quesTxt.text = ques.NameQues;
        A.SetText(ques.Ans1);
        B.SetText(ques.Ans2);
        C.SetText("Next question");
        group = ques.Group;
        this.gameObject.SetActive(true);
        UI_Input.SetActive(false);
    }
    public void HidePanel()
    {
        this.gameObject.SetActive (false);
        UI_Input.SetActive(true);
    }
    
    public void DisplayVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void TakeResult(int result)
    {
        quesController.TakeResult(result , group);
    }
}
