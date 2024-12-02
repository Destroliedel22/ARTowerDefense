using Oculus.Interaction;
using UnityEngine;

public class GrabDroppedItem : MonoBehaviour
{
    CustomITransformer ITransformer;

    private void Awake()
    {
        ITransformer = GetComponentInChildren<CustomITransformer>();
    }

    private void FixedUpdate()
    {
        if(ITransformer.state == CustomITransformer.grabState.lettingGo)
        {
            CoinManager.Instance.AddCoin(1);
            gameObject.SetActive(false);
        }
    }
}
