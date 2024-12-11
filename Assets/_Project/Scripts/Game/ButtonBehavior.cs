using System.Collections;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void DisableButton()
    {
        StartCoroutine(WaitForDisable());
    }

    IEnumerator WaitForDisable()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}