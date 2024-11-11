using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Health
    private float maxHealth = 5;
    private float currentHealth;

    // Move to the base
    private float speed = 0.01f;
    private GameObject homeBase;

    // Change this bool in an ontriggerenter
    public bool reachedBase = false;

    // Attack
    [SerializeField] private float enemyStrength;
    private bool hasAttacked = false;
    private BaseHealth baseHealth;
    private Animator animator;


    // FSM States = moving, attacking, dying, winning


    private void Start()
    {
        // Find base
        homeBase = GameObject.FindGameObjectWithTag("Base");

        // Set health
        currentHealth = maxHealth;

        // Get components
        baseHealth = FindFirstObjectByType<BaseHealth>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // If base is not destroyed yet
        if (homeBase != null)
        {
            if (!reachedBase)
            {
                MoveToBase();
            }
        }
    }

    private void Update()
    {
        // If the enemy has not reached the base yet, move towards it
        if (reachedBase)
        {
            Attacking();
        }
    }

    private void MoveToBase()
    {
        // Enemy looks at the base
        transform.LookAt(homeBase.transform.position);

        // Enemy moves towards the base
        Vector3 targetPos = Vector3.MoveTowards(transform.position, homeBase.transform.position, speed);
        transform.position = targetPos;
    }

    // Get this function in the animation to damage the base
    private void AttackBase()
    {
        baseHealth.TakeDamage(enemyStrength);
    }

    // Attacking state
    private void Attacking()
    {
        // Bool to stop animation
        bool win = false;

        if (!hasAttacked)
        {
            hasAttacked = true;
            animator.SetTrigger("Attack");
        }

        if (!win)
        {
            win = true;
            Victory();
        }
    }

    // If enemy does not have any health, it will die
    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Play dying animation
            Destroy(gameObject);
        }
    }

    // Stop attacking and go to victory state
    private void Victory()
    {
        if (baseHealth.currentHealth <= 0)
        {
            animator.SetTrigger("Win");
        }
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}