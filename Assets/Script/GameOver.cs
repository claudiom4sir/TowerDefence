using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public SceneFader sceneFader;
    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = "WAVE " + PlayerStatistic.rounds;
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
