using Oculus.Interaction.HandGrab;
using UnityEngine;

public class LockPlayfield : MonoBehaviour
{
    private Canvas lockCanvas;
    private GameObject grabObject;

    public bool isLocked;
    public GameObject LockedButton;
    public GameObject UnlockedButton;

    private void Awake()
    {
        lockCanvas = GetComponentInChildren<Canvas>();
        grabObject = GetComponentInChildren<HandGrabInteractable>().gameObject;
    }

    //locks playfield 
    public void Lock()
    {
        grabObject.SetActive(false);
        LockedButton.SetActive(false);
        UnlockedButton.SetActive(true);
        gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);
        isLocked = true;
    }
}