using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    void Update()
    {
        // Sahnedeki tüm "rakip" etiketli nesneleri kontrol et
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("rakip");

        // Eðer sahnede "rakip" etiketli nesne kalmadýysa
        if (enemies.Length == 0)
        {
            // Sonraki seviyeye geç
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Mevcut sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin indeksine geç
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}