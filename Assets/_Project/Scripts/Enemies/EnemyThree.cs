using UnityEngine;

public class EnemyThree : Enemy // Zombie
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 2;
        speed = 0.07f;
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