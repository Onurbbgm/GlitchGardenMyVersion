using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter = 3f;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }          
        if(SceneManager.GetActiveScene().name == "Splash-Screen")
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
