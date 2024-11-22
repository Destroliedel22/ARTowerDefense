using Oculus.Interaction.HandGrab;
using UnityEngine;

public class LockPlayfield : MonoBehaviour
{
    private GameObject grabObject;

    public bool isLocked;

    private void Awake()
    {
        grabObject = GetComponentInChildren<HandGrabInteractable>().gameObject;
    }

    //locks playfield 
    public void Lock()
    {
        grabObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);
        isLocked = true;
    }
}