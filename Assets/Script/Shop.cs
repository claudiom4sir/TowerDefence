using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretCostsInfo stantardTurret;
    public TurretCostsInfo missilLauncherTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret() // it allows to change the turret to build
    {
        buildManager.SelectTurretToBuild(stantardTurret);
    }

    public void SelectMissilLauncherTurret() // like the method over
    {
        buildManager.SelectTurretToBuild(missilLauncherTurret);
    }

}
