using UnityEngine;

public class EnemyOne : Enemy
{
    protected override void Start()
    {
        base.Start();
        enemyStrength = 1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}