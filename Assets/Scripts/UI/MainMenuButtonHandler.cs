using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    private SceneHandler sceneHandler;
    private void Awake()
    {
        sceneHandler = FindObjectOfType<SceneHandler>();
        playButton.onClick.AddListener(() => sceneHandler.LoadScene(Scenes.GameScene));
        quitButton.onClick.AddListener(() => Application.Quit());
            
    }
    public void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;   
    }

}
