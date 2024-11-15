using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Unity.XR.CoreUtils;
using UnityEngine;

public class DefenseDetection : MonoBehaviour
{
    GameObject grabObject;
    bool isPlaced;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            grabObject = collision.gameObject.GetNamedChild("[BuildingBlock] HandGrab");
            if (collision.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false)
            {
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.transform.SetParent(transform);
                collision.transform.rotation = Quaternion.Euler(0, 0, 0);
                collision.gameObject.GetNamedChild("[BuildingBlock] HandGrab").SetActive(false);
                isPlaced = true;
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
    //        isPlaced = false;
    //    }
    //}
}
