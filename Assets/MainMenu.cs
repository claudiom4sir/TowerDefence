using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load the level after the menu in buildIndex
    }

    public void Quit()
    {
        Debug.Log("quitting from application");
        Application.Quit();
    }
}
