using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorControlller : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void Awake()
    {
       gameObject.GetComponent<Renderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openTrigger)
            {
               /* Debug.Log("Open");*/
                myDoor.Play("DoorOpen", 0,0.0f);
                /*gameObject.SetActive(false);*/
                openTrigger = false;
                closeTrigger = true;

            }
            else if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
               /* gameObject.SetActive(false);*/
                openTrigger = true;
                closeTrigger = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
