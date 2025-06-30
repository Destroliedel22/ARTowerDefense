using UnityEngine;

public class BaseFirework : MonoBehaviour
{
    [SerializeField] private GameObject fireworkPrefab;

    // Animation
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        fireworkPrefab.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.wonGame)
        {
            fireworkPrefab.SetActive(true);
            animator.SetTrigger("ActivateFirework");
            GameManager.Instance.wonGame = false;
        }
    }
}