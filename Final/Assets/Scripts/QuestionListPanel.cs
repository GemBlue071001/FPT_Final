using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuestionListPanel : MonoBehaviour
{
    public QuestionController controller;
    public QuestionItemUI itemPrb;
    public ScrollRect scrollView;

    private List<QuestionItemUI> items;

    public void OnEnable()
    {
        DisplayQuestionList();
    }
    private void OnDisable()
    {
        ClearView();
    }
    private void DisplayQuestionList()
    {
        if(items == null) { items = new List<QuestionItemUI>(); }
        foreach(Question ques in controller.ListAnswered)
        {
            QuestionItemUI clone = Instantiate(itemPrb, scrollView.content);
            clone.Init(true, ques.NameQues);
            items.Add(clone);
        }
        foreach (Question ques in controller.ListQuesNotAnswered)
        {
            QuestionItemUI clone = Instantiate(itemPrb, scrollView.content);
            clone.Init(false, ques.NameQues);
            items.Add(clone);
        }
    }

    private void ClearView()
    {
        if(items != null)
        {
            for(int i = items.Count - 1; i >= 0; i--)
            {
                Destroy(items[i].gameObject);
                items.RemoveAt(i);
            }
        }
    }
}
