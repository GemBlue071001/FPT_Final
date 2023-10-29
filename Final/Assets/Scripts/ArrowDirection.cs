using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    public Transform player;
    public GameObject arrow;
    public List<Transform> targetList;

    private Transform currTarget;
    private void Awake()
    {
        currTarget = targetList[0];
        targetList.RemoveAt(0);
    }

    private void LateUpdate()
    {
        Vector3 targetPos = currTarget.position;
        targetPos.y = player.position.y;
        Vector3 direction = targetPos - player.position;
        arrow.transform.forward = direction.normalized;
        arrow.transform.position = player.position + new Vector3(0f,0.1f,0f);
    }
    public void SetNextTarget()
    {
        if(targetList.Count > 0)
        {
            currTarget = targetList[0];
            targetList.RemoveAt(0);
        }
        else
        {
            arrow.gameObject.SetActive(false);
        }
    }
}
