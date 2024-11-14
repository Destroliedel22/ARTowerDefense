using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class DefenseDetection : MonoBehaviour
{
    GameObject grabObject;
    bool isPlaced;

    private void Awake()
    {
        grabObject = gameObject.GetComponentInChildren<CustomITransformer>().gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            if (collision.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false)
            {
                collision.transform.rotation = Quaternion.Euler(0, 0, 0);
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                grabObject.SetActive(false);
                isPlaced = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            grabObject.SetActive(true);
            isPlaced = false;
        }
    }
}
