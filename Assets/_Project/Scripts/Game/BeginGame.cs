using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField] LockPlayfield lockPlayfield;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Begin();
            gameObject.SetActive(false);
        }
    }

    private void Begin()
    {
        GameManager.Instance.StartGame();
        lockPlayfield.Lock();
        gameObject.SetActive(false);
    }
}