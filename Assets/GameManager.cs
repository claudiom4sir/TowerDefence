using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameEnded = false;

	// Update is called once per frame
	void Update () {
        if (gameEnded)  // for dont repeat EndGame() every frame when game is already ended
            return;
		if(PlayerStatistic.lives <= 0)
        {
            EndGame();
        }
	}

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game over");
    }
}
