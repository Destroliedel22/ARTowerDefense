using Oculus.Interaction;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class DefenseDetection : MonoBehaviour
{
    public List<GameObject> PlacedTurrets = new List<GameObject>();

    private GameObject grabObject;

    //locks the turret on the playfield
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collisiom");
        if (collision.gameObject.CompareTag("Defense"))
        {
            GameObject defense = collision.gameObject;
            //grabObject = defense.GetNamedChild("[BuildingBlock] HandGrab");
            if (defense.GetComponentInChildren<CustomITransformer>().state == CustomITransformer.grabState.unGrabbed)
            {
                defense.GetComponent<Rigidbody>().useGravity = false;
                defense.GetComponent<Rigidbody>().isKinematic = true;
                defense.transform.SetParent(transform);
                defense.transform.rotation = Quaternion.Euler(0, 0, 0);
                //defense.GetNamedChild("[BuildingBlock] HandGrab").SetActive(false);
                defense.GetComponent<TurretOne>().IsPlaced = true;
                PlacedTurrets.Add(defense);
            }
        }
    }
}
