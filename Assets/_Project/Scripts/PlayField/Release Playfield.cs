using Oculus.Interaction;
using UnityEngine;

public class ReleasePlayfield : MonoBehaviour
{
    public void OnRelease()
    {
        
    }

    private void Update()
    {
        if(gameObject.GetComponentInChildren<ITransformerPlayfield>().isGrabbed == false)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
