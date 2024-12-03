using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------> Audio source <-------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("-------> Audio clips <-------")]
    public AudioClip background;
    public AudioClip newRound;
    public AudioClip newWave;
    public AudioClip enemyDeath;
    public AudioClip enemyTakeDamage;
    public AudioClip enemyHitWithHands;
    public AudioClip baseDamage;
    public AudioClip collectLoot;
    public AudioClip buyInShop;
    public AudioClip powerUpActive;
    public AudioClip powerUpEnd;
    public AudioClip turretShoot;
    public AudioClip turretPlaced;
    public AudioClip gameWon;
    public AudioClip gameLost;
    public AudioClip lostExplosion;
    public AudioClip buttonPress;
    public AudioClip fingerInteraction;

    #region Singleton
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            // Check if there is something in this instance
            if (instance == null)
            {
                Debug.Log("AudioManager is empty");
            }
            // Return the instance to have it be read
            return instance;
        }
    }

    private void Awake()
    {
        // If instance is not empty, destroy this, meaning there can be only 1 audio manager
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    private void Start()
    {
        // Play the background music
        musicSource.clip = background;
        musicSource.Play();
    }

    // Call this function where we want to play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}