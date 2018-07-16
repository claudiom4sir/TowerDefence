using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Boo gameEnded = false;

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
        gameEnded = true;
    }
}
