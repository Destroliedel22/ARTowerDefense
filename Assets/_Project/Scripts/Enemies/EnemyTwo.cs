using UnityEngine;

public class EnemyTwo : Enemy // Spider
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
        speed = 0.13f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}