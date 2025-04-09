using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseBt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenPause()
    {
        pausePanel.SetActive(true);
        pauseBt.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseBt.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
