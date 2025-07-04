using UnityEngine;

public class Enemy : MonoBehaviour
{
    // States for all the enemies
    protected enum enemyStates
    {
        moveToBase = 0,
        attackBase,
        die,
        win
    }

    protected enemyStates states;

    protected float speed;

    // Move to the base
    private GameObject homeBase;
    private Transform target;
    private Transform currentWaypoint;
    private int wayPointIndex = 0;
    private float rotationSpeed = 0.2f;

    // Change this bool in an ontriggerenter
    public bool reachedBase = false;

    // Attack
    private bool hasAttackedBase = false;
    protected float enemyStrength;

    // Health
    [SerializeField] protected GameObject dyingEffect;

    // Health components for damage
    private BaseHealth baseHealth;
    private Animator animator;
    private EnemyHealth health;

    private EnemyWaveSpawner enemySpawner;

    protected virtual void Start()
    {
        // Find base
        homeBase = GameObject.FindGameObjectWithTag("Base");

        // Get components
        health = GetComponent<EnemyHealth>();
        baseHealth = FindFirstObjectByType<BaseHealth>();
        animator = GetComponent<Animator>();

        // Get first waypoint
        target = Waypoints.points[0];

        enemySpawner = FindFirstObjectByType<EnemyWaveSpawner>();
    }

    protected virtual void FixedUpdate()
    {
        UpdateStates();
        HandleStates();
    }

    private void UpdateStates()
    {
        switch (states)
        {
            case enemyStates.moveToBase:
                MoveToBaseState();
                break;
            case enemyStates.attackBase:
                AttackingBaseState();
                break;
            case enemyStates.die:
                DeathState();
                break;
            case enemyStates.win:
                VictoryState();
                break;
            default:
                break;
        }
    }

    private void HandleStates()
    {
        // If base is not destroyed yet
        if (homeBase != null)
        {
            // Move to base
            if (!reachedBase)
            {
                states = enemyStates.moveToBase;
            }
            else
            {
                // If base has been reached, attack
                states = enemyStates.attackBase;
            }
        }
        // If base has been destroyed
        else
        {
            states = enemyStates.win;
        }

        CheckForDeath();
    }

    // If there is no more health, then die
    private void CheckForDeath()
    {
        if (health.currentHealth <= 0)
        {
            states = enemyStates.die;
        }
    }

    private void MoveToBaseState()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        RotateTowardsWayPoint();

        // When enemy is at waypoint go to the next
        if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        // When at last waypoint
        if (wayPointIndex >= Waypoints.points.Length - 1)
        {
            // Attack?
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    // Rotate towards waypoint
    private void RotateTowardsWayPoint()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
    }

    // Attacking states
    private void AttackingBaseState()
    {
        // Reset the attack animation
        if (!hasAttackedBase)
        {
            hasAttackedBase = true;
            animator.SetTrigger("AttackBase");
        }
    }

    #region Attack in animation
    // Get this function in the animation to damage the base
    private void AttackBase()
    {
        baseHealth.TakeDamage(enemyStrength);
    }
    #endregion

    // If enemy does not have any health, it will die
    public virtual void DeathState()
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.enemyDeath);
        // Drop a random item when enemy dies
        GetComponent<EnemyItemHolder>().DropItemOnDeath(transform.position);
        // Remove from list when enemy dies
        enemySpawner.RemoveEnemies(gameObject);
        // Particle effect

        health.currentHealth = 0;
        // Play dying animation
        Destroy(gameObject);
    }

    // Stop attacking and go to victory state
    private void VictoryState()
    {
        animator.SetTrigger("Win");
    }
}