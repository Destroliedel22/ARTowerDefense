using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerCanvas;
    public float remainingTime;

    public bool cooldownActivated = false;

    private void Start()
    {
        timerCanvas.SetActive(false);
    }

    private void Update()
    {
        if (cooldownActivated)
        {
            StartTimerTime();
        }
    }

    private void StartTimerTime()
    {
        // While the timer has not reached 0 yet, it will count down
        if (remainingTime >= 0.1f)
        {
            remainingTime -= Time.deltaTime;
            timerCanvas.SetActive(true);
        }
        else
        {
            remainingTime = 0;
            cooldownActivated = false;
            timerCanvas.SetActive(false);
        }

        // The way the timer is displayed
        int time = Mathf.FloorToInt(remainingTime);
        timerText.text = time.ToString();
    }
}