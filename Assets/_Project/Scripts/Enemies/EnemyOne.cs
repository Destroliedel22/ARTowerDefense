using UnityEngine;

public class EnemyOne : Enemy // Slime
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
        speed = 0.1f;
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