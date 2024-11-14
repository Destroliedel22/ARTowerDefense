using Oculus.Interaction;
using UnityEngine;

public class ReleasePlayfield : MonoBehaviour
{
    private ITransformerPlayfield iTransformerScript;

    private void Awake()
    {
        iTransformerScript = gameObject.GetComponentInChildren<ITransformerPlayfield>();
    }

    private void Update()
    {
        if(iTransformerScript.isGrabbed == false && iTransformerScript != null)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
        }
    }
}
