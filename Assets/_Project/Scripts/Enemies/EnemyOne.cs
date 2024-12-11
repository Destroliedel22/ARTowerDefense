using UnityEngine;

public class EnemyOne : Enemy // Slime
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
        speed = 0.1f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}