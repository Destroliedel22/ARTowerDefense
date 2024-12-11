using UnityEngine;

public class EnemyTwo : Enemy // Spider
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
        speed = 0.13f;
        dyingEffect.SetActive(false);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void DeathState()
    {
        base.DeathState();
        dyingEffect.SetActive(true);
    }
}