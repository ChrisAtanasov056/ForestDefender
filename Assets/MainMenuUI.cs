using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
     public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void EndGame()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
