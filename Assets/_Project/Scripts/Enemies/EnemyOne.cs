using UnityEngine;

public class EnemyOne : Enemy
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
        speed = 0.005f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}