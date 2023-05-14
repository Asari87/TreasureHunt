using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { MainMenuScene, GameScene, GameOverScene}
public class SceneHandler : MonoBehaviour
{
    private Fader fader;
    private void Awake()
    {
        fader = FindObjectOfType<Fader>();
    }
    public void LoadScene(Scenes nextScene)
    {
        StartCoroutine(SwtichScene(nextScene));
    }

    private IEnumerator SwtichScene(Scenes nextScene)
    {
        yield return fader.FadeOut(1);
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene.ToString());
        while (op.progress < .9f)
        {
            yield return null;
        }

        //move player here


        yield return fader.FadeIn(1);
    }
}
