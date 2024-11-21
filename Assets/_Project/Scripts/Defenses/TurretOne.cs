using System.Collections;
using UnityEngine;

public class TurretOne : Turrets
{
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject shootingEffect;

    private Coroutine coroutine;

    private void FixedUpdate()
    {
        // Constantly look at the enemy when it is in range
        if (states == turretStates.attack)
        {
            FocusEnemy();
            LookAtEnemy();
        }
    }

    private void FocusEnemy()
    {
        // Set the target to the first enemy
        if (target == null)
        {
            target = GameObject.FindWithTag("Enemies");
        }
    }

    private void LookAtEnemy()
    {
        //Check if another turret has not destroyed this enemy yet
        if (target != null)
        {
            // Rotate towards the head towards the enemy
            head.transform.forward = transform.position - target.transform.position;
        }
    }

    private void Shoot()
    {
        shootingEffect.SetActive(true);
    }

    private IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(0.8f);
        Shoot();
        yield return new WaitForSeconds(0.5f);
        shootingEffect.SetActive(false);
        // Stop coroutine
        coroutine = null;
    }

    protected override void AttackingState()
    {
        // Only call coroutine when it is null (so it won't be called non stop) and only when turret is placed
        if (coroutine == null && IsPlaced)
        {
            coroutine = StartCoroutine(WaitForShoot());
        }
    }
}