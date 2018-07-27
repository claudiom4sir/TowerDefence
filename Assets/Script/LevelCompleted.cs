using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class LevelCompleted : MonoBehaviour {

    public Text roundText;
    public SceneFader sceneFader;
    public float delayAnimation = 0.05f; // it is used for to choose the time in AnimateText()

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() // it is used for animate the roundText with incremental round effect
    {
        int round = 0;
        roundText.text = "WAVE " + round;
        yield return new WaitForSeconds(1.5f);
        while(round < PlayerStatistic.rounds)
        {
            round++;
            roundText.text = "WAVE " + round;
            yield return new WaitForSeconds(delayAnimation);
        }
    }

    public void Continue()
    {
        sceneFader.FadeTo("LevelSelector");
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }

}
