using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public GameObject ui;

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
        if (Time.timeScale != 1f)   // for restart the scene with currect timeScale
            Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("menu");
    }

}
