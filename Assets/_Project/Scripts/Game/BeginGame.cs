using UnityEngine;

public class BeginGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
