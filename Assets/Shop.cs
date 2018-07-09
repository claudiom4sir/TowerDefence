using UnityEngine;

public class Shop : MonoBehaviour {

	public void SelectStandardTurret() // it allows to change the turret to build
    {
        BuildManager.instance.SetTurretToBuild(BuildManager.instance.standardTurret);
    }

    public void SelectMissilLauncherTurret() // like the method over
    {
        BuildManager.instance.SetTurretToBuild(BuildManager.instance.missilLauncherTurret);
    }

}
