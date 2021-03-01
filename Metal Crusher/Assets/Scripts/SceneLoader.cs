using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // can now use Scene Management library

public class SceneLoader : MonoBehaviour
{

   public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // within the scene manager class, run method of GetActiveScene, find out the current build index
        SceneManager.LoadScene(currentSceneIndex + 1); // loading the next scene
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit(); // only works in a standalone build, not in the editor
    }
}
