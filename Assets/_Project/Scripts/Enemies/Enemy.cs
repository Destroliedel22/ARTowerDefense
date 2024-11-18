using UnityEngine;

public class Enemy : MonoBehaviour
{
    // States for all the enemies
    protected enum enemyStates
    {
        moveToBase = 0,
        moveToTurret,
        attackBase,
        attackTurret,
        die,
        win
    }

    [SerializeField] protected enemyStates states;

    // Move to the base
    private float speed = 0.01f;
    private GameObject homeBase;

    // Move to turret
    private GameObject foundTurret;

    // Change this bool in an ontriggerenter
    public bool reachedBase = false;
    public bool reachedTurret = false;

    // Attack
    [SerializeField] private LayerMask turretLayer;
    private float radius = 2f;
    private bool hasAttackedBase = false;
    private bool hasAttackedTurret = false;

    protected float enemyStrength;

    // Health components for damage
    private BaseHealth baseHealth;
    private TurretHealth turretHealth;
    private Animator animator;

    // Health
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
            case enemyStates.moveToTurret:
                MoveToTurretState();
                break;
            case enemyStates.attackBase:
                AttackingBaseState();
                break;
            case enemyStates.attackTurret:
                AttackingTurretState();
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

        // If a turret is in the way, destroy that first
        LookForTurret();
        CheckForDeath();
    }

    // Check if there are any enemies within attack range
    private void LookForTurret()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, turretLayer);
        // If a turret has been found move towards that turret first to destroy it, once it is gone move towards the base again
        if (colliders.Length > 0)
        {
            FoundTurret();
            states = enemyStates.moveToTurret;
        }
        else
        {
            //states = enemyStates.moveToBase;
        }
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
        // Enemy looks at the base
        transform.LookAt(homeBase.transform.position);

        // Enemy moves towards the base
        Vector3 targetPos = Vector3.MoveTowards(transform.position, homeBase.transform.position, speed);
        transform.position = targetPos;
    }

    // Find the turret to focus it
    private void FoundTurret()
    {
        if (foundTurret == null)
        {
            foundTurret = GameObject.FindGameObjectWithTag("Defense");
        }
    }

    private void MoveToTurretState()
    {
        if(foundTurret.GetComponentInParent<TurretOne>().IsPlaced)
        {
            // Enemy looks at the turret
            transform.LookAt(foundTurret.transform.position);

            // Enemy moves towards the turret
            Vector3 targetPos = Vector3.MoveTowards(transform.position, foundTurret.transform.position, speed);
            transform.position = targetPos;

            // Right place?????????????????????????????
            ReachedTurret();
        }
    }

    private void ReachedTurret()
    {
        if (reachedTurret)
        {
            states = enemyStates.attackTurret;
        }
        else
        {
            states = enemyStates.moveToTurret;
        }
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

    private void AttackingTurretState()
    {
        // Reset the attack animation
        if (!hasAttackedTurret)
        {
            hasAttackedTurret = true;
            animator.SetTrigger("AttackTurret");
        }
    }

    // Get this function in the animation to damage the base
    private void AttackBase()
    {
        baseHealth.TakeDamage(enemyStrength);
    }

    // Get this function in the animation to damage the turrets/////////////////////////////////////////////////////////////////////////////////////////doesnt work
    private void AttackTurret()
    {
        turretHealth = gameObject.GetComponent<TurretHealth>();
        if (turretHealth != null)
        {
            turretHealth.TakeDamage(enemyStrength);
        }
    }

    // If enemy does not have any health, it will die
    private void DeathState()
    {
        enemySpawner.RemoveEnemies(enemySpawner.enemy);
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