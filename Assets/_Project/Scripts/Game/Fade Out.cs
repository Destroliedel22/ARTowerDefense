using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreenFadeOut : MonoBehaviour
{
    private float fadeAmount;
    void Start()
    {
        fadeAmount = gameObject.GetComponent<Renderer>().material.color.a;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (fadeAmount >= 0.01f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeAmount);
            yield return new WaitForSeconds(0.025f);
            fadeAmount -= 0.015f;

            if (fadeAmount <= 0.01f)
            {
                yield return new WaitForSeconds(1);
                gameObject.SetActive(false);
            }
        }

    }
}
