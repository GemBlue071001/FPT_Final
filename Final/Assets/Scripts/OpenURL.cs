using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
   public void OpenUrl()
    {
        Application.OpenURL("https://www.facebook.com/miquanajoy/");
        Debug.Log("Tam ngu");

    }
}
