using UnityEngine;

public class PlayerStatistic : MonoBehaviour {

    public static int money;
    public int startMoney;
    public static int lives;
    public int startLives;

	// Use this for initialization
	private void Start () {
        money = startMoney;
        lives = startLives;
	}

    public static void LoseOneLife()
    {
        lives--;
    }
	
	
}
