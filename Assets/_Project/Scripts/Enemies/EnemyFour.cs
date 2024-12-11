using UnityEngine;

public class EnemyFour : Enemy // Goblin
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 2;
        speed = 0.06f;
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