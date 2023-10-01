using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    private bool isQuestCompleted = false;
    [SerializeField]  PopUpManager popUpManager;

   

    void Start()
    {   
        
        if (isQuestCompleted)
        {
            FinishQuest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            FinishQuest();
            // Check if the PopUpManager instance exists before accessing its properties
            if (PopUpManager.instance != null)
            {
                PopUpManager.instance.ShowPopup();
            }
            else
            {
                Debug.LogError("PopUpManager instance is not assigned.");
            }
        }
    }

    public void FinishQuest()
    {
        isQuestCompleted = true;
        questItem.color = completedColor;
        /*PopUpManager.instance.HidePopup();*/

        // Optionally, you can call a method to handle other quest completion actions here.
    }
}
