using Oculus.Interaction;
using UnityEngine;

public class ReleasePlayfield : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.GetComponentInChildren<ITransformerPlayfield>().isGrabbed == false)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
        }
    }
}
