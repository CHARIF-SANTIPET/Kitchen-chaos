using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject HowToPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Mygame01", LoadSceneMode.Single);
    }

    public void HowToBt()
    {
        HowToPanel.SetActive(true);
    }

    public void HowToClose()
    {
        HowToPanel.SetActive(false);
    }



}
