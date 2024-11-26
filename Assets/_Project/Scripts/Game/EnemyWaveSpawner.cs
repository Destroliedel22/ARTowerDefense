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
    // The instantiated clone enemy
    public GameObject cloneEnemy;

    [Header("Enemy waves")]
    [SerializeField] private float enemyGroupAmount = 5;
    [SerializeField] private float delay = 1f;

    private void Update()
    {
        // Not in update?
        if (GameManager.Instance.canSpawnWave)
        {
            GameManager.Instance.canSpawnWave = false;
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        float waitForWave = 5;

        StartCoroutine(WaitForSpawn(waitForWave));
    }

    // Wait a while before spawning a new wave
    private IEnumerator WaitForSpawn(float waitTime)
    {
        // First wave
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < enemyGroupAmount; i++)
        {
            cloneEnemy = Instantiate(enemy, transform.position, transform.rotation);
            AddEnemies(cloneEnemy);
            yield return new WaitForSeconds(delay);
        }
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