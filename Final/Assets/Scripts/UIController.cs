using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button OpenMenuBtn;
    public GameObject questionList;
    private void Awake()
    {
        OpenMenuBtn.onClick.AddListener(() =>
        {
            questionList.SetActive(!questionList.activeInHierarchy);
        });
    }
}
