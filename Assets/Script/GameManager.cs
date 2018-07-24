using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    private void Start()
    {
        gameEnded = false;
        if(Time.timeScale != 1f)
            Time.timeScale = 1f;
    }
    // Update is called once per frame
    private void Update()
    {
        if (gameEnded)
            return;
        if (PlayerStatistic.lives <= 0 || Input.GetKey(KeyCode.G))
            EndGame();
        if (Input.GetKeyDown(KeyCode.Space))
            PausedGame();
    }

    private void EndGame()
    {
        GameManager.gameEnded = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void PausedGame()
    {
        pauseUI.GetComponent<PauseGame>().TogglePauseUI();
    }
}
