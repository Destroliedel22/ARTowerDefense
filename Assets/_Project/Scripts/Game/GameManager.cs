using System.Collections.Generic;
using UnityEngine;

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
    private int maxWaves;
    [SerializeField] private List<int> waves = new List<int>();

    public bool canSpawnWave = false;

    // Rounds
    private int currentRound = 0;
    private bool roundCompleted = false;

    public bool enemiesKilled = false;
    public bool enemiesWon = false;

    private void Awake()
    {
        // Set the instance, so we can change it
        instance = this;
    }

    private void Start()
    {
        gameStart = true;
    }

    private void Update()
    {
        StartGame();

        if (enemiesWon)
        {
            GameOverScreen();
        }

        if (enemiesKilled)
        {
            // Removes one wave after all the enemies have been killed
            UpdateWave(1);
        }

        if (roundCompleted)
        {
            StartNewRound();
        }
    }

    private void StartGame()
    {
        if (gameStart)
        {
            gameStart = false;
            StartNewRound();
        }
    }

    private void StartNewRound()
    {
        // Add 1 round every time a round has been completed
        UpdateRound(1);
        // Then check in which round we are to set the amount of waves
        SetWaveAmount();
        // Activate wave spawner
        canSpawnWave = true;
    }

    private void UpdateWave(int finishedWave) // 1
    {
        // If all the enemies have been killed and there are still waves to come, spawn new enemies
        if (enemiesKilled)
        {
            enemiesKilled = false;
            waves.Remove(finishedWave);
            canSpawnWave = true;
        }

        // If all the waves have come and all the enemies are killed, then start a new wave
        if (waves.Count <= 0 && enemiesKilled)
        {
            roundCompleted = true;
        }
    }

    private void SetWaveAmount()
    {
        // Increase the amount of waves based on the rounds
        if (currentRound == 1 || currentRound == 2)
        {
            maxWaves = 3;
        }
        if (currentRound == 3 || currentRound == 4)
        {
            maxWaves = 5;
        }

        // Add the amount of waves to the list
        waves.Add(maxWaves);
    }


    // Add a round every time it is completed
    private void UpdateRound(int roundsWon)
    {
        currentRound += roundsWon;
    }

    private void GameOverScreen()
    {
        // Game over logic
        // Freeze or remove the plane
        // A button will appear from the ground up which allows you to retry or quit
    }
}