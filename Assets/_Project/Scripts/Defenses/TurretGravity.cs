using Oculus.Interaction;
using UnityEngine;

public class TurretGravity : MonoBehaviour
{
    void Update()
    {
        if(GetComponentInChildren<CustomITransformer>().IsGrabbed)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
