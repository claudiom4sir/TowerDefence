using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public SceneFader sceneFader;
    public Text roundsText;
    public float delayAnimation = 0.05f;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() // it is used for animate the roundText with incremental round effect
    {
        int round = 0;
        roundsText.text = "WAVE " + round;
        yield return new WaitForSeconds(1.5f);
        while (round < PlayerStatistic.rounds)
        {
            round++;
            roundsText.text = "WAVE " + round;
            yield return new WaitForSeconds(delayAnimation);
        }
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
