using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonHandler : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        // Daha önce butona týklanýp týklanmadýðýný kontrol et
        if (PlayerPrefs.GetInt("RestartButtonUsed", 0) == 1)
        {
            restartButton.gameObject.SetActive(false);
        }
        else
        {
            // Butonun týklama eventine metot baðlama
            restartButton.onClick.AddListener(OnRestartButtonClick);
        }
    }

    void OnRestartButtonClick()
    {
        // Bölümü yeniden yükleme
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Butonun bir daha kullanýlmamasý için durumu kaydet
        PlayerPrefs.SetInt("RestartButtonUsed", 1);
    }
}