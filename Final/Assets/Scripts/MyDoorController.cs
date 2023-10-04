using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAim;
    private bool doorOpen = false;

    // Update is called once per frame

    private void Awake()
    {
     doorAim = gameObject.GetComponent<Animator>();   
    }
    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
    void Update()
    {
        
    }
}
