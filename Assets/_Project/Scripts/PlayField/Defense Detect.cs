using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Runtime.CompilerServices;
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
            GameObject defense = collision.gameObject;
            grabObject = collision.gameObject.GetNamedChild("[BuildingBlock] HandGrab");
            if (collision.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false && lockPlayfield.isLocked)
            {
                defense.GetComponent<Rigidbody>().useGravity = false;
                defense.GetComponent<Rigidbody>().isKinematic = true;
                defense.transform.SetParent(transform);
                defense.transform.rotation = Quaternion.Euler(0, 0, 0);
                defense.GetNamedChild("[BuildingBlock] HandGrab").SetActive(false);
                IsPlaced = true;
                if(defense.transform.position.y < 0.943f)
                   defense.transform.position = new Vector3(defense.transform.position.x, 0.943f, defense.transform.position.z);
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
