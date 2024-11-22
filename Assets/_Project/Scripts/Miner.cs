using Oculus.Interaction;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] private int coinsOnPickaxe;

    public bool onCrystal;

    private void Update()
    {
        if(onCrystal)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    public void addCurrency()
    {
        if (onCrystal)
        {
            CoinManager.Instance.AddCoin(coinsOnPickaxe);
        }
    }
}
