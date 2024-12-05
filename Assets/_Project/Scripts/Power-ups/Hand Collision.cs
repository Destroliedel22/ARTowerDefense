using System.Collections;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    [SerializeField] private float waitTime = 20f;
    [SerializeField] private Transform[] handObjects;

    [SerializeField] private LayerMask handLayer;
    [SerializeField] private LayerMask defaultLayer;

    private void Start()
    {
        GetHandObjects();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.GetMask("Hands");
        }
    }

    private void GetHandObjects()
    {
        handObjects = GetComponentsInChildren<Transform>();
    }

    private IEnumerator AbilityActiveTime()
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateAbility();
    }

    private void DeactivateAbility()
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpEnd);
        GetHandObjects();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Hands");
        }
    }

    public void ActivatePowerUp()
    {
        GetHandObjects();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = defaultLayer - 1;
        }
        StartCoroutine(AbilityActiveTime());
    }
}