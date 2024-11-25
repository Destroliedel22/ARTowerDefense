using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    float fadeAmount = 0;
    public void Retry()
    {
        sphere.SetActive(true);
        StartCoroutine(BlackScreenFadeIn());
    }

    IEnumerator BlackScreenFadeIn()
    {
        while (fadeAmount <= 1)
        {
            sphere.GetComponent<Renderer>().material.color = new Color(0, 0, 0, fadeAmount);
            yield return new WaitForSeconds(0.025f);
            fadeAmount += 0.015f;

            if (fadeAmount >= 0.999f)
            {
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene(0);
            }
        }

    }

    public void Quit()
    {
        Application.Quit();
    }
}
