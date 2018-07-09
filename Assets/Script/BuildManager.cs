using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;
    public GameObject standardTurret;
    public GameObject missilLauncherTurret;
    public static BuildManager instance;

    void Awake ()
    {
        instance = this;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject TurretToBuild ()
    {
        return turretToBuild;
    }

}
