using UnityEngine;

public class PlayerStatistic : MonoBehaviour {

    public static int money;
    public int startMoney;
    public static int lives;
    public int startLives;
    public static int rounds;

	// Use this for initialization
	private void Start () {
        money = startMoney;
        lives = startLives;
        rounds = 0;
	}

}
