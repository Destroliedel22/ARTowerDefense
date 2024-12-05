using Oculus.Interaction.HandGrab;
using UnityEngine;

public class LockPlayfield : MonoBehaviour
{
    [SerializeField] private GameObject grabObject;

    public bool isLocked;

    //locks playfield 
    public void Lock()
    {
        grabObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);
        isLocked = true;
    }
}