using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField] LockPlayfield lockPlayfield;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        lockPlayfield.Lock();
        gameObject.SetActive(false);
    }
}
