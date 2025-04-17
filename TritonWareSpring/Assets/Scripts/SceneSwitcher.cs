using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class LayerSwitcher : MonoBehaviour
{
    public GameObject farmLayer;
    public GameObject kitchenLayer;

    public Vector3 moveOut = new Vector3(20, 0, 0);      // Offscreen right
    public Vector3 moveIn = new Vector3(0, 0, 0);     // Center screen
    public Vector3 moveInFarm = new Vector3(0, 0, 0);

    public Image fadePanel;
    public float fadeDuration = 1f;

    private bool isFading = false;

    public void SwitchToKitchen()
    {
        if (!isFading)
            StartCoroutine(FadeAndMove(farmLayer, moveOut, kitchenLayer, moveIn));
    }

    public void SwitchToFarm()
    {
        if (!isFading)
            StartCoroutine(FadeAndMove(kitchenLayer, moveOut, farmLayer, moveInFarm));
    }


    private IEnumerator FadeAndMove(GameObject currentLayer, Vector3 OffScreen, GameObject toNewLayer, Vector3 toNewPos)
    {
        isFading = true;

        // Fade to black
        yield return StartCoroutine(Fade(0f, 1f));

        // Move both layers
        currentLayer.transform.position = OffScreen; // Move current layer out
        toNewLayer.transform.position = toNewPos;     // Bring target layer in

        // Fade back in
        yield return StartCoroutine(Fade(1f, 0f));

        isFading = false;
    }


    //Fades to black using Panel Object
    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadePanel.color;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadePanel.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        fadePanel.color = color;
    }
}
