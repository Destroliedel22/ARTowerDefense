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

    // Waves
    [SerializeField] private int currentWave = 0;
    private int maxWaves;
    [SerializeField] private List<Wave> waves = new List<Wave>();

    // Rounds
    [SerializeField] private int currentRound;
    private bool roundCompleted = false;

    public bool canSpawnWave = false;
    public bool enemiesKilled = false;
    public bool enemiesWon = false;

    private void Awake()
    {
        // Set the instance, so we can change it
        instance = this;
    }

    private void Update()
    {
        if (enemiesKilled)
        {
            // Removes one wave after all the enemies have been killed
            UpdateWave();
        }  // maybe else { GameOverScreen } // not enemiesWon bool

        if (roundCompleted)
        {
            StartNewRound();
        }

        if (enemiesWon)
        {
            GameOverScreen();
        }
    }

    private void StartNewRound()
    {
        // Add 1 round every time a round has been completed
        currentRound++;
        // Then check in which round we are to set the amount of waves
        SetWaveAmount();
        // Activate wave spawner
        canSpawnWave = true;
        roundCompleted = false;
    }

    private void UpdateWave()
    {
        // If all the enemies have been killed and there are still waves to come, spawn new enemies
        if (enemiesKilled)
        {
            // Remove 1 from maxWaves
            //waves.Remove(finishedWave);

            for (int i = 0; i > maxWaves; i--)
            {
                currentWave--;
            }
            enemiesKilled = false;
            canSpawnWave = true;

            // If all the waves have come and all the enemies are killed, then start a new wave
            if (currentWave == 0) // or if maxWaves <= 0
            {
                roundCompleted = true;
            }
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
        for (int i = 0; i < maxWaves; i++)
        {
            currentWave = maxWaves;
            //waves.Add(Wave1);
        }
        //waves.Add(maxWaves);
    }

    private void GameOverScreen()
    {
        // Game over logic
        // Freeze or remove the plane
        // A button will appear from the ground up which allows you to retry or quit
    }

    public void StartGame()
    {
        StartNewRound();
    }
}