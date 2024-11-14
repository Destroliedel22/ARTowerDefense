using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.UI;

public class LockPlayfield : MonoBehaviour
{
    private Canvas lockCanvas;
    private bool isLocked;

    public Sprite LockedImg;
    public Sprite UnlockedImg;

    private void Awake()
    {
        lockCanvas = GetComponentInChildren<Canvas>();
    }

    public void Lock()
    {
        switch (isLocked)
        {
            case true:
                gameObject.transform.GetComponentInChildren<HandGrabInteractable>().enabled = true;
                lockCanvas.GetComponentInChildren<Image>().sprite = UnlockedImg;
                isLocked = false;
                Debug.Log("unlocked");
                break;
            case false:
                gameObject.transform.GetComponentInChildren<HandGrabInteractable>().enabled = false;
                lockCanvas.GetComponentInChildren<Image>().sprite = LockedImg;
                isLocked = true;
                Debug.Log("locked");
                break;
        }
    }
}
