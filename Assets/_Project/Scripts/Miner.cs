using Oculus.Interaction;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Miner : MonoBehaviour
{
    Grabbable grabObject;
    //Transform closestMineable = null;
    //Collider[] colliders;

    [SerializeField] LayerMask mineableLayer;

    private void Awake()
    {
        grabObject = GetComponentInChildren<Grabbable>();
    }

    //private void FixedUpdate()
    //{
    //    if(grabObject.GetComponentInChildren<CustomITransformer>().IsGrabbed)
    //    {
    //        ProjectMiner();
    //    }
    //}

    //private void ProjectMiner()
    //{
    //    if(GetClosestMineable() != null)
    //    {
    //        GetClosestMineable().gameObject.GetNamedChild("Projected Miner").SetActive(true);
    //    }
    //}

    //Transform GetClosestMineable()
    //{
    //    /*Collider[]*/ colliders = Physics.OverlapSphere(this.gameObject.transform.position, 1f, mineableLayer);

    //    //Transform closestMineable = null;
    //    float closestDist = Mathf.Infinity;

    //    foreach (var collider in colliders)
    //    {
    //        float dist = Vector3.Distance(collider.transform.position, this.transform.position);
    //        if (dist < closestDist)
    //        {
    //            closestMineable = collider.transform;
    //            closestDist = dist;
    //        }
    //        else
    //        {
    //            collider.gameObject.GetNamedChild("Projected Miner").SetActive(false);
    //        }
    //    }

    //    return closestMineable;
    //}
}
