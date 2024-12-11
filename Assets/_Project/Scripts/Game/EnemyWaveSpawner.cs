using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWaveSpawner : MonoBehaviour
{
    // Add enemies to a list
    // When killed remove from list
    // When list is 0 set bool

    [SerializeField] private List<GameObject> spawnedEnemies = new List<GameObject>();

    public GameObject[] enemies1;
    public GameObject[] enemies2;
    // The instantiated clone enemy
    public GameObject cloneEnemy;

    [Header("Enemy waves")]
    private float enemyGroupAmount = 2;
    private float delay = 1f;

    // Countdown timer
    private CountdownTimer countdownTimer;

    private void Start()
    {
        countdownTimer = FindFirstObjectByType<CountdownTimer>();
    }

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

        // Increase the enemies by 2 every new wave
        IncreaseEnemyGroupAmount(2);
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.newWave);
        // Start countdown timer
        countdownTimer.remainingTime = waitForWave + 1;
        countdownTimer.cooldownActivated = true;
        StartCoroutine(WaitForSpawn(waitForWave));
    }

    // Wait a while before spawning a new wave
    private IEnumerator WaitForSpawn(float waitTime)
    {
        // First wave
        yield return new WaitForSeconds(waitTime);

        // Enemies in a row
        for (int i = 0; i < enemyGroupAmount; i++)
        {
            if (GameManager.Instance.currentRound == 1 || GameManager.Instance.currentRound == 2)
            {
                GameObject cloneEnemies1 = enemies1[Random.Range(0, enemies1.Length)];
                cloneEnemy = Instantiate(cloneEnemies1, transform.position, transform.rotation);
            }
            else
            {
                GameObject cloneEnemies2 = enemies2[Random.Range(0, enemies2.Length)];
                cloneEnemy = Instantiate(cloneEnemies2, transform.position, transform.rotation);
            }
            AddEnemies(cloneEnemy);

            yield return new WaitForSeconds(delay);
        }
    }

    // Void to possibly make public for GM?
    private void IncreaseEnemyGroupAmount(int amount)
    {
        enemyGroupAmount = enemyGroupAmount + amount;
    }

    // Add the instantiated enemies
    private void AddEnemies(GameObject addedEnemy)
    {
        spawnedEnemies.Add(addedEnemy);
    }

    // Remove the enemies in enemy script (when they die)
    public void RemoveEnemies(GameObject removedEnemy)
    {
        spawnedEnemies.Remove(removedEnemy);

        UpdateList();
    }

    private void UpdateList()
    {
        // Check if all the enemies are killed
        if (spawnedEnemies.Count == 0)
        {
            GameManager.Instance.enemiesKilled = true;
        }
        else
        {
            GameManager.Instance.enemiesKilled = false;
        }
    }
}