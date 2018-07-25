using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = "ROUND " + PlayerStatistic.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.gameEnded = false;
    }

    public void Menu()
    {
        Debug.Log("menu");
    }
}
