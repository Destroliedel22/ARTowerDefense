using UnityEngine;

public class EnemyThree : Enemy // Zombie
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 2;
        speed = 0.07f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}