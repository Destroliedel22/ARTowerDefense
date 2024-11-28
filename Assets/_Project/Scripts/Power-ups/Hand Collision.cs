using System.Collections;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    [SerializeField] private float waitTime = 5f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void DeactivateAbility()
    {
        rb.excludeLayers = LayerMask.GetMask("Enemies"); ;
    }
    public void ActivatePowerUp()
    {
        rb.excludeLayers = LayerMask.GetMask("Nothing");
        StartCoroutine(AbilityActiveTime());
    }

    private IEnumerator AbilityActiveTime()
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateAbility();
    }

}
