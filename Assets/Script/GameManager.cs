using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;

    private void Start()
    {
        gameEnded = false;
    }
    // Update is called once per frame
    private void Update ()
    {
        if (gameEnded)
            return;
        if (PlayerStatistic.lives <= 0 || Input.GetKey(KeyCode.G))
            EndGame();
	}

    private void EndGame()
    {
        GameManager.gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
