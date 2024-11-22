using Oculus.Interaction;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private bool inCollider;

    private GameObject miner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Miner"))
        {
            inCollider = true;
            miner = other.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if(miner != null && miner.gameObject.GetComponent<Miner>().onCrystal == false)
        {
            if (miner.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false && inCollider)
            {
                miner.gameObject.transform.parent = this.gameObject.transform;
                miner.gameObject.transform.position = this.gameObject.GetNamedChild("MinerTransform").transform.position;
                miner.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                miner.gameObject.GetComponentInChildren<CustomITransformer>().gameObject.SetActive(false);
                miner.gameObject.GetComponent<Miner>().onCrystal = true;
            }
        }
    }
}
