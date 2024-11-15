using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Unity.XR.CoreUtils;
using UnityEngine;

public class DefenseDetection : MonoBehaviour
{
    private GameObject grabObject;
    private LockPlayfield lockPlayfield;

    public bool IsPlaced;

    private void Awake()
    {
        lockPlayfield = GetComponent<LockPlayfield>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            grabObject = collision.gameObject.GetNamedChild("[BuildingBlock] HandGrab");
            if (collision.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false) //&& lockPlayfield.isLocked)
            {
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.transform.SetParent(transform);
                collision.transform.rotation = Quaternion.Euler(0, 0, 0);
                collision.gameObject.GetNamedChild("[BuildingBlock] HandGrab").SetActive(false);
                IsPlaced = true;
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Defense"))
    //    {
    //        collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
    //        collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //        collision.gameObject.transform.SetParent(transform);
    //        grabObject.SetActive(true);
    //        IsPlaced = false;
    //    }
    //}
}
