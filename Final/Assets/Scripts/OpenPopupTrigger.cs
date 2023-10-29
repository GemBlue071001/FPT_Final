
using UnityEngine;

public class OpenPopupTrigger : MonoBehaviour
{
    public QuestionController questionController;
    public ArrowDirection arrowDirection;
    public int numQues;
    bool isOpened = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            isOpened = true;
            questionController.StartAnswering(numQues);
            arrowDirection.SetNextTarget();

        }
    }
}
