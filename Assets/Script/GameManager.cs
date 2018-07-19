using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameEnded = false;
    public GameObject gameOverUI;

	// Update is called once per frame
	private void Update ()
    {
        if (gameEnded)
            return;
        if (PlayerStatistic.lives <= 0)
            EndGame();
	}

    private void EndGame()
    {
        Debug.Log("game over");
        gameOverUI.SetActive(true);
    }
}
