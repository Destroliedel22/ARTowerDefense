using UnityEngine;

public abstract class Turrets : MonoBehaviour, IHold
{
    // Check for enemies
    [SerializeField] private LayerMask enemyLayer;

    protected Collider[] colliders;
    private float radius = 0.4f;
    // The focused enemy
    [SerializeField]protected GameObject target;

    // States for all the turrets
    protected enum turretStates
    {
        idle = 0,
        attack,
        //die
    }

    [SerializeField] protected turretStates states;

    private Rigidbody rb;

    // Health
    //private TurretHealth health;

    // Placed on playfield true or false
    public bool IsPlaced = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //health = GetComponent<TurretHealth>();

        // Temporary for unity testing
        IsPlaced = true;
    }

    private void Update()
    {
        SearchForEnemy();
        UpdateStates();

/*        // Put somewhere not in update
        if (health.currentHealth <= 0)
        {
            states = turretStates.die;
        }*/
    }

    // Check if there are any enemies within attack range
    private void SearchForEnemy()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        // If an enemy has been found go to attack state, else go to idle state
        if (colliders.Length > 0)
        {
            states = turretStates.attack;
        }
        else
        {
            states = turretStates.idle;
        }
    }

    #region Turret states
    private void IdleState()
    {
        target = null;
    }

    // Override this state per turret for a different attack
    protected abstract void AttackingState();

/*    private void DeathState()
    {
        // Dying animation
    }
*/
    private void UpdateStates()
    {
        switch (states)
        {
            case turretStates.idle:
                IdleState();
                break;
            case turretStates.attack:
                AttackingState();
                break;
/*            case turretStates.die:
                DeathState();
                break;*/
            default:
                break;
        }
    }
    #endregion

    #region IHold
    public void OnStartHold()
    {
        rb.useGravity = false;
    }

    public void OnStopHold()
    {
        rb.useGravity = true;
        rb.linearVelocity = Vector3.one;
    }
    #endregion
}