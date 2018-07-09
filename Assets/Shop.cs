using UnityEngine;

public class Shop : MonoBehaviour {

    public BuildManager buildManager;

	public void SelectedStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurret);
    }

    public void SelectedAnotherTurret()
    {
        buildManager.SetTurretToBuild(null);
    }

}
