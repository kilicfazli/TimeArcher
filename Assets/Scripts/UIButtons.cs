using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    int levelNumber = 0;

    void Start()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
    }

    public void playGame()
    {
        levelNumber += 1;
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("anaMenu");
    }
    public void newGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void finishMenu()
    {
        SceneManager.LoadScene("FinishMenu");
    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}