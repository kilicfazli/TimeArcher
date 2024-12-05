using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 20f;
    private float currentTime;
    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = levelTime;
        UpdateTimerText();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            LoadPreviousLevel();
        }
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    void LoadPreviousLevel()
    {
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        if (currentScene.name == "1")
        {
            // Reload the current scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
        }
        else
        {
            // Load the previous scene
            int currentSceneIndex = currentScene.buildIndex;
            int previousSceneIndex = currentSceneIndex > 0 ? currentSceneIndex - 1 : 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(previousSceneIndex);
        }
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        UpdateTimerText();
    }
}