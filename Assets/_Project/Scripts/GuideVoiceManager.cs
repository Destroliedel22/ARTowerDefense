using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideVoiceManager : MonoBehaviour
{
    [SerializeField] public List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private GameObject firstButton;
    [SerializeField] private GameObject tutorialButton;

    private bool tutorialFinished;
    private AudioSource audioSource;
    private int audioNum;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioNum = -1;
        StartCoroutine(StartTutorial());
    }

    public void TutorialFinished()
    {
        tutorialFinished = true;
    }

    public void NextStep()
    {
        if(audioNum < audioClips.Count)
        {
            audioNum++;
        }
        audioSource.clip = audioClips[audioNum];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if(tutorialFinished == false)
        {
            StartCoroutine(ReplayAudio());
        }
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        firstButton.SetActive(true);
        tutorialButton.SetActive(true);
        NextStep();
    }

    IEnumerator ReplayAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        yield return new WaitForSeconds(8f);
        StartCoroutine(ReplayAudio());
    }
}
