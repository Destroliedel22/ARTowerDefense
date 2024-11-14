using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.UI;

public class LockPlayfield : MonoBehaviour
{
    [SerializeField] GameObject grabObject;

    private Canvas lockCanvas;
    private bool isLocked;

    public GameObject LockedButton;
    public GameObject UnlockedButton;

    private void Awake()
    {
        lockCanvas = GetComponentInChildren<Canvas>();
    }

    //locks playfield 
    public void Lock()
    {
        grabObject.SetActive(false);
        LockedButton.SetActive(false);
        UnlockedButton.SetActive(true);
        gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
        isLocked = true;
    }

    //unlocks playfield
    public void Unlock()
    {
        grabObject.SetActive(true);
        LockedButton.SetActive(true);
        UnlockedButton.SetActive(false);
        isLocked = false;
    }
}
