using Oculus.Interaction;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class DefenseDetection : MonoBehaviour
{
    public List<GameObject> PlacedTurrets = new List<GameObject>();

    private GameObject grabObject;
    private LockPlayfield lockPlayfield;

    private void Awake()
    {
        lockPlayfield = GetComponent<LockPlayfield>();
    }

    //locks the turret on the playfield
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
                defense.GetComponent<TurretOne>().IsPlaced = true;
                PlacedTurrets.Add(defense);
            }
        }
    }
}
