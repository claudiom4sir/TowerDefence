using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;

    public GameObject standardTurret;

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject TurretToBuild ()
    {
        return standardTurret;
    }

}
