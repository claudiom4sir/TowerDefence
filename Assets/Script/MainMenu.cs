using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public SceneFader sceneFader;
    public string levelToLoad = "LevelSelector";

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll(); // <-- used for test, i have to delete before deploy
        Debug.Log("quitting from application");
        Application.Quit();
    }
}
