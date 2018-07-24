using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    private void Start()
    {
        gameEnded = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (gameEnded)
            return;
        if (PlayerStatistic.lives <= 0 || Input.GetKey(KeyCode.G))
            EndGame();
        if (Input.GetKeyDown(KeyCode.Space))
            pauseUI.GetComponent<PauseGame>().TogglePauseUI();
    }

    private void EndGame()
    {
        GameManager.gameEnded = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
