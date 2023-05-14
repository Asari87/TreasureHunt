using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine fadeRoutine;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    

    public Coroutine FadeIn(float fadeInTime)
    {
        return Fade(fadeInTime, 0);
    }
    public Coroutine FadeOut(float fadeOutTime) 
    {
        return Fade(fadeOutTime, 1);
    }

    private Coroutine Fade(float fadeTime, float alphaTarget)
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeRoutine(alphaTarget, fadeTime));
        return fadeRoutine;
    }

    private IEnumerator FadeRoutine(float alphaTarget, float fadeTime)
    {
        while(canvasGroup.alpha != alphaTarget)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, alphaTarget, fadeTime * Time.deltaTime);
            yield return null;
        }
    }


    
}
