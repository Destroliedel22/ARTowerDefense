using Oculus.Interaction;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private bool inCollider;

    private GameObject miner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Miner"))
        {
            Debug.Log("detect miner");
            inCollider = true;
        }
    }

    private void Awake()
    {
        miner = FindFirstObjectByType<Miner>().gameObject;
    }

    private void FixedUpdate()
    {
        if(miner != null)
        {
            if (miner.gameObject.GetComponentInChildren<CustomITransformer>().IsGrabbed == false && inCollider)
            {
                miner.gameObject.transform.parent = this.gameObject.transform;
                miner.gameObject.transform.position = this.gameObject.GetNamedChild("MinerTransform").transform.position;
                miner.gameObject.GetComponentInChildren<CustomITransformer>().gameObject.SetActive(false);
                Debug.Log("let go");
            }
        }
    }
}
