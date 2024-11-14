using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWaveSpawner : MonoBehaviour
{
    // Add enemies to a list
    // When killed remove from list
    // When list is 0 set bool

    private List<GameObject> enemies = new List<GameObject>();

    public GameObject enemy;

    private void Update()
    {
        // Not in update?
        if (GameManager.Instance.canSpawnWave)
        {
            GameManager.Instance.canSpawnWave = false;
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        float waitingTime = 5;

        StartCoroutine(WaitForSpawn(waitingTime));
    }

    // Wait a while before spawning a new wave
    private IEnumerator WaitForSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(enemy, transform.position, transform.rotation);
        AddEnemies(enemy);
    }

    // Add the instantiated enemies
    private void AddEnemies(GameObject addedEnemy)
    {
        enemies.Add(addedEnemy);
    }

    // Remove the enemies in enemy script (when they die)
    public void RemoveEnemies(GameObject removedEnemy)
    {
        enemies.Remove(removedEnemy);

        UpdateList();
    }

    private void UpdateList()
    {
        // Check if all the enemies are killed
        if (enemies.Count == 0)
        {
            GameManager.Instance.enemiesKilled = true;
        }
        else
        {
            GameManager.Instance.enemiesKilled = false;
        }
    }
}