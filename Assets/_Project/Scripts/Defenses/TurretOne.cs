using System;
using System.Collections;
using System.Linq;
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
        target = colliders[0].gameObject;
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
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.turretShoot);
        shootingEffect.SetActive(true);
    }

    public void PalmShoot()
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.turretShoot);
        shootingEffect.SetActive(true);
        StartCoroutine(WaitForPalmShoot());
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

    private IEnumerator WaitForPalmShoot()
    {
        yield return new WaitForSeconds(0.5f);
        shootingEffect.SetActive(false);
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