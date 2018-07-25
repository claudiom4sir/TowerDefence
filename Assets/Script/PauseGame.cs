using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public GameObject ui;
    public SceneFader sceneFader;

    public void TogglePauseUI()
    {
        ui.SetActive(!ui.activeSelf); // if is active, it will be disactived and viceversa
        if (ui.activeSelf)
            Time.timeScale = 0f; // for to freeze the time
        else
            Time.timeScale = 1f; // for to make the time as normal
    }

    public void Retry()
    {
        GameManager.ResetTimeScale();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        GameManager.ResetTimeScale();
        sceneFader.FadeTo("MainMenu");
    }

}
