using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class HandDefenseDetection : MonoBehaviour
{
    public List<GameObject> PlacedTurrets = new List<GameObject>();

    private GameObject grabObject;
    private Transform turretTranform;
    private Transform turretHead;
    private bool turretPlaced;

    private void Awake()
    {
        turretTranform = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Defense"))
        {
            GameObject defense = other.gameObject;
            grabObject = defense.GetNamedChild("[BuildingBlock] HandGrab");
            if (defense.GetComponentInChildren<CustomITransformer>().IsGrabbed == false && turretPlaced == false)
            {
                turretHead = defense.GetNamedChild("Head").transform;
                defense.GetComponent<Rigidbody>().useGravity = false;
                defense.GetComponent<Rigidbody>().isKinematic = true;
                defense.transform.SetParent(turretTranform);
                defense.transform.localPosition = Vector3.zero;
                defense.transform.localRotation = Quaternion.Euler(Vector3.zero);
                defense.GetNamedChild("[BuildingBlock] HandGrab").SetActive(false);
                turretHead.transform.position = new Vector3(0, turretHead.localPosition.y, 0);
                defense.GetComponent<TurretOne>().enabled = false;
                defense.GetComponent<TurretOne>().IsPlaced = true;
                turretPlaced = true;
                PlacedTurrets.Add(defense);
            }
        }
    }

    public void TurretShoot()
    {
        if(turretPlaced)
        {
            turretTranform.GetComponentInChildren<TurretOne>().PalmShoot();
        }
    }
}
