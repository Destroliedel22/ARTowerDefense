using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    float fadeAmount = 0;
    public void FadeBegin()
    {
        gameObject.SetActive(true);
        StartCoroutine(BlackScreenFadeIn());
    }

    IEnumerator BlackScreenFadeIn()
    {
        while (fadeAmount < 1)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeAmount);
            yield return new WaitForSeconds(0.03f);
            fadeAmount += 0.015f;

            if (fadeAmount >= 0.95f)
            {
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}
