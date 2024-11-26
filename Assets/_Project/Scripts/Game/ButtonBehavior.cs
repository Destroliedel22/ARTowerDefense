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
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}