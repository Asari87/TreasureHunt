using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private Button restartButton;


    private void Awake()
    {
        restartButton.onClick.AddListener(() => 
        { 
            StopAllCoroutines();
            FindObjectOfType<SceneHandler>().LoadScene(Scenes.MainMenuScene); 
        });
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveAllListeners();
    }
    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("Score");
        StartCoroutine(UpdateScore(currentScore));
    }

    private IEnumerator UpdateScore(int currentScore)
    {
        float tempScore = 0;
        while(tempScore < currentScore)
        {
            tempScore = Mathf.Lerp( tempScore, currentScore, 10 * Time.deltaTime );
            score.text = tempScore.ToString("f0");
            yield return null;
        }
    }


}
