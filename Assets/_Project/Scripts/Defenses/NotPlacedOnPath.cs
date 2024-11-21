using UnityEngine;

public class NotPlacedOnPath : MonoBehaviour
{
    private Turrets turrets;

    private void OnCollisionEnter(Collision collision)
    {
        if (turrets = collision.gameObject.GetComponent<Turrets>())
        {
            turrets.IsPlaced = false;
        }
    }
}