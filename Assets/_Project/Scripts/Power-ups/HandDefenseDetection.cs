using Oculus.Interaction;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class HandDefenseDetection : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float powerupCooldown;

    private GameObject defense;
    private Transform turretParent;
    private Transform turretTranform;
    private Transform turretHead;
    private bool turretPlaced;
    private float force = 50;

    private void Awake()
    {
        turretTranform = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Defense"))
        {
            defense = other.gameObject;
            turretParent = defense.transform.parent;
            if (defense.GetComponentInChildren<CustomITransformer>().IsGrabbed == false && turretPlaced == false)
            {
                turretHead = defense.GetNamedChild("Head").transform;
                defense.GetComponent<Rigidbody>().useGravity = false;
                defense.GetComponent<Rigidbody>().isKinematic = true;
                defense.transform.SetParent(turretTranform);
                defense.transform.localPosition = Vector3.zero;
                defense.transform.localRotation = Quaternion.Euler(Vector3.zero);
                turretHead.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
                defense.GetComponent<TurretOne>().enabled = false;
                defense.GetComponent<TurretOne>().IsPlaced = true;
                turretPlaced = true;
                StartCoroutine(TurretCooldown());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Defense"))
        {
            AfterCooldown();
        }
    }

    private void AfterCooldown()
    {
        defense.transform.parent = turretParent;
        defense.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Force);
        defense.GetComponent<Rigidbody>().useGravity = true;
        defense.GetComponent<Rigidbody>().isKinematic = false;
        defense.GetComponent<TurretOne>().enabled = true;
        defense.GetComponent<TurretOne>().IsPlaced = false;
    }

    IEnumerator TurretCooldown()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(cooldown);
        AfterCooldown();
        yield return new WaitForSeconds(powerupCooldown);
        GetComponent<Collider>().enabled = true;
    }

    public void TurretShoot()
    {
        if(turretPlaced)
        {
            turretTranform.GetComponentInChildren<TurretOne>().PalmShoot();
        }
    }

    public void ActivatePowerUpTwo()
    {

    }
}
