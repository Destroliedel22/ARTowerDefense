using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideVoiceManager : MonoBehaviour
{
    [SerializeField] public List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private GameObject firstButton;

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
        StartCoroutine(StopAudio());
        StartCoroutine(ReplayAudio());
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        firstButton.SetActive(true);
        NextStep();
    }

    IEnumerator StopAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length + 0.5f);
        audioSource.Stop();
    }

    IEnumerator ReplayAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        StartCoroutine(StopAudio());
        yield return new WaitForSeconds(5f);
        StartCoroutine(ReplayAudio());
    }
}
