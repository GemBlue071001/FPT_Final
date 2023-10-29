using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Close");
    }
}
