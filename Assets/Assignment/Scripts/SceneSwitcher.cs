using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // This script handles the reset and game states, alongside switching screens
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
