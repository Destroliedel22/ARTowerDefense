using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.UI;

public class LockPlayfield : MonoBehaviour
{
    [SerializeField] GameObject grabObject;

    private Canvas lockCanvas;

    public GameObject LockedButton;
    public GameObject UnlockedButton;

    private void Awake()
    {
        lockCanvas = GetComponentInChildren<Canvas>();
    }

    public void Lock()
    {
        grabObject.SetActive(false);
        LockedButton.SetActive(false);
        UnlockedButton.SetActive(true);
        Debug.Log("locked");
    }

    public void Unlock()
    {
        grabObject.SetActive(true);
        LockedButton.SetActive(true);
        UnlockedButton.SetActive(false);
        Debug.Log("unlocked");
    }
}
