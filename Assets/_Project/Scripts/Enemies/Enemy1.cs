using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private float speed = 0.01f;
    private GameObject homeBase;

    private void Start()
    {
        homeBase = GameObject.Find("Base");
    }

    private void FixedUpdate()
    {
        if (homeBase != null)
        {
            MoveToBase();
        }
    }

    private void MoveToBase()
    {
        Vector3 targetPos = Vector3.MoveTowards(transform.position, homeBase.transform.position, speed);
        transform.position = targetPos;
    }
}