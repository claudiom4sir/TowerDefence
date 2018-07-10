using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour {

    public Text textMoney;
	
	// Update is called once per frame
	private void Update () {
        textMoney.text = "€" + PlayerStatistic.Money; // update the text with the current money
	}
}
