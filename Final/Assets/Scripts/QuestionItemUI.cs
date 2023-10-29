using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItemUI : MonoBehaviour
{
    public Sprite lockSpr;
    public Sprite unLockSpr;

    public Image icon;
    public TextMeshProUGUI text;

    public void Init(bool isUnlocked , string txt)
    {
        icon.sprite = isUnlocked ? unLockSpr : lockSpr;
        text.text = txt;
    }
}
