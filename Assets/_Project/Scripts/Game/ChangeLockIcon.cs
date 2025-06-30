using UnityEngine;

public class ChangeLockIcon : MonoBehaviour
{
    [SerializeField] private GameObject unlockIcon;
    [SerializeField] private GameObject lockIcon;

    private void Start()
    {
        unlockIcon.SetActive(true);
        lockIcon.SetActive(false);
    }

    // Change icon on click
    public void ChangeIconToLocked()
    {
        unlockIcon.SetActive(false);
        lockIcon.SetActive(true);
    }

    // Void just in case
    public void ChangeIconToUnlocked()
    {
        unlockIcon.SetActive(true);
        lockIcon.SetActive(false);
    }
}