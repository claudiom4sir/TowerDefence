using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStatistic.rounds.ToString();
    }

    public void Retry()
    {
        if (Time.timeScale != 1f)
            Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.gameEnded = false;
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }
}
