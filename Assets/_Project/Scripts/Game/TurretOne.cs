using UnityEngine;

public class TurretOne : MonoBehaviour, IHold
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnStartHold()
    {
        rb.useGravity = false;
    }

    public void OnStopHold()
    {
        rb.useGravity = true;
        rb.linearVelocity = Vector3.one;
    }
}