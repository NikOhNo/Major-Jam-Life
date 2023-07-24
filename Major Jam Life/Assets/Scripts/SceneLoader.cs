using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    public void LoadNextScene()
    {
        int nextSceneIndex = 1 + SceneManager.GetActiveScene().buildIndex;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadSceneName(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
