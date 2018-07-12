using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour {

    public Text textLives;

    private void Update()
    {
        textLives.text = PlayerStatistic.lives + " LIVES"; 
    }
}
