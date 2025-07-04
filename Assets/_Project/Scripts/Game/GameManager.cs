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

    // Rounds
    private bool roundCompleted = false;
    public int currentRound = 0;

    public bool canSpawnWave = false;
    public bool enemiesKilled = false;
    public bool enemiesWon = false;

    // Gameloop
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject buttons;

    // Death explosion
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private LayerMask enemyMask;
    private GameObject explosionPoint;

    private float radius = 10;
    private float explosionForce = 5;
    private float upwardsModifier = 1;

    // For firework script
    public bool wonGame = false;

    private void Awake()
    {
        explosionPoint = GameObject.Find("Explosion Point");
        explosionEffect.SetActive(false);

        // Set the instance, so we can change it
        instance = this;
    }

    private void Update()
    {
        if (enemiesKilled)
        {
            // Removes one wave after all the enemies have been killed
            UpdateWave();
            // Checks for round 5
            GameWon();
        }

        if (roundCompleted)
        {
            StartNewRound();
            roundCompleted = false;
        }

        if (enemiesWon)
        {
            GameOver();
        }
    }


    // If all the enemies have been killed and there are still waves to come, spawn new enemies
    private void UpdateWave()
    {
        // Remove 1 from maxWaves
        currentWave--;
        canSpawnWave = true;

        enemiesKilled = false;

        // If all the waves have come and all the enemies are killed, then start a new wave
        if (currentWave == 0)
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

        currentWave = maxWaves;
    }

    private void GameOver()
    {
        // Add explosion in middle of field when the player dies
        Collider[] colliders = Physics.OverlapSphere(explosionPoint.transform.position, radius, enemyMask);
        foreach (Collider collider in colliders)
        {
            collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint.transform.position, upwardsModifier);
        }
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.lostExplosion);
        explosionEffect.SetActive(true);
        game.SetActive(false);

        buttons.SetActive(true); // doesnt need to?
    }

    private void GameWon()
    {
        if (currentRound == 5)
        {
            // Game won effect
            wonGame = true;
        }
    }

    public void StartNewRound()
    {

        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.newRound);
        // Add 1 round every time a round has been completed
        currentRound++;
        // Then check in which round we are to set the amount of waves
        SetWaveAmount();
        // Activate wave spawner
        canSpawnWave = true;
    }

    public void SpawnGame()
    {
        game.SetActive(true);
        shop.SetActive(true);
    }
}