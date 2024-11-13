using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Check if game has started
    // Check in which round we are
    // Check how many waves have spawned
    // Check if the base has been destroyed (player lost)
    // Check if all the waves have been cleared (player won)

    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            // Check if the instance is empty
            if (instance == null)
            {
                Debug.LogWarning("There is no instance of GameManager");
            }
            // Return the instance
            return instance;
        }
    }
    #endregion

    // Game // Check if player has placed the base/ field
    private bool gameStart = false;

    // Waves
    private float waitingTime;
    private int maxWaves;
    private int currentWave;
    private int[] waves;
    public bool waveCompleted = false;

    // Rounds
    private int currentRound = 0;
    private bool roundCompleted = false;
    public bool enemiesWon = false;

    private void Awake()
    {
        // Set the instance, so I can change it if I need to
        instance = this;
    }

    private void Start()
    {
        // Set the current wave equal to the waves in the array
        currentWave = waves[0];
    }

    private void Update()
    {
        StartGame();

        if (enemiesWon)
        {
            GameOverScreen();
        }
    }

    private void StartGame()
    {
        // Decrease the waiting time 
        waitingTime = 10;

        if (gameStart)
        {
            UpdateWave(1);
            StartCoroutine(WaitForSpawn(waitingTime));
        }
    }

    // Wait a while before spawning a new wave
    private IEnumerator WaitForSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNewWave();
    }

    private void SetWaveAmount()
    {
        // Increase the amount of waves based on the rounds
    }

    private void SpawnNewWave()
    {
        
    }

    // Add a wave every time
    private void UpdateWave(int amount)
    {
        waves[currentWave] += amount;
    }

    private void GameOverScreen()
    {

    }
}