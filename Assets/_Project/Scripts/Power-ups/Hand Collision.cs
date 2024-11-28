using System.Collections;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    [SerializeField] private float waitTime = 5f;
    private Rigidbody rb;
    private Transform[] handObjects;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetHandObjects();
    }
    private void DeactivateAbility()
    {
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.GetMask("Hands");
        }
    }
    public void ActivatePowerUp()
    {
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.GetMask("Default");
        }
        StartCoroutine(AbilityActiveTime());
    }

    private IEnumerator AbilityActiveTime()
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateAbility();
    }

    private void GetHandObjects()
    {
        handObjects = GetComponentInChildren<Transform[]>();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.GetMask("Hands");
        }
    }
}
