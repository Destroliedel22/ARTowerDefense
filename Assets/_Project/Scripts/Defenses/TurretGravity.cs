using Oculus.Interaction;
using UnityEngine;

public class TurretGravity : MonoBehaviour
{
    private CustomITransformer customITransformer;

    private void Awake()
    {
        customITransformer = GetComponentInChildren<CustomITransformer>();
    }

    void Update()
    {
        if(customITransformer.state == CustomITransformer.grabState.lettingGo)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
