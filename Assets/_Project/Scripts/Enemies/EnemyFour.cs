using UnityEngine;

public class EnemyFour : Enemy // Goblin
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 2;
        speed = 0.06f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}