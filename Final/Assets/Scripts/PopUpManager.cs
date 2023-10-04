    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PopUpManager : MonoBehaviour
    {
        public static PopUpManager instance { get; private set; }
        public GameObject popupCanvas; // Reference to the Canvas containing the pop-up UI


    /* private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player") )
         {

             ShowPopup();
         }
     }*/
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null &&instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    // Call this function to show the pop-up
    public void ShowPopup()
        {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
        popupCanvas.SetActive(true);
        }

        // Call this function to hide the pop-up
        public void HidePopup()
        {
       
        popupCanvas.SetActive(false);
        }
    }
