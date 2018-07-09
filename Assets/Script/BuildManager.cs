using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild = null;
    public GameObject standardTurret;
    public GameObject anotherTurret;

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject TurretToBuild ()
    {
        return turretToBuild;
    }

}
