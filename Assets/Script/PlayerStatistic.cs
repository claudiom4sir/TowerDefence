using UnityEngine;

public class PlayerStatistic : MonoBehaviour {

    public static int money;
    public int startMoney;
    public static int lives;
    public int startLives;
    public static int rounds;
    public static int enemyKilled;

	// Use this for initialization
	private void Start () {
        money = startMoney;
        lives = startLives;
        rounds = 0;
        enemyKilled = 0;
	}

}
