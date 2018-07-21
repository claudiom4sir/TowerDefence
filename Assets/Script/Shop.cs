using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public TurretCostsInfo stantardTurret;
    public TurretCostsInfo missilLauncherTurret;
    public TurretCostsInfo laserTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        UpdatePriceOfTurretPanel();
    }

    private void UpdatePriceOfTurretPanel() // it is used if the price of the turrets changes, it automatically will display the current price
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Text text;
        foreach (Button button in buttons)
        {
            text = button.GetComponentInChildren<Text>();
            if (button.name.Contains("Standard"))
                text.text = stantardTurret.buildCost.ToString();
            else if (button.name.Contains("Missil"))
                text.text = missilLauncherTurret.buildCost.ToString();
            else if (button.name.Contains("Laser"))
                text.text = laserTurret.buildCost.ToString();
            else
                Debug.Log("The name of the button in Shop doesnt exist");
        }

    }

    public void SelectStandardTurret() // it allows to change the turret to build
    {
        buildManager.SelectTurretToBuild(stantardTurret);
    }

    public void SelectMissilLauncherTurret() // like the method over
    {
        buildManager.SelectTurretToBuild(missilLauncherTurret);
    }

    public void SelectLaserTurret() // like the method over
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }

}
