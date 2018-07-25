﻿using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    private void Start()
    {
        gameEnded = false;  // when you restart the level, it is used for set a static variable to false
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
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    private void PausedGame()
    {
        pauseUI.GetComponent<PauseGame>().TogglePauseUI();
    }

    public static void ResetTimeScale() // it is used everytime appear pause or gameover UIs
    {
        Time.timeScale = 1f;
    }
}
