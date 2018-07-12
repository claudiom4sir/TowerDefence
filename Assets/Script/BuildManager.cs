using UnityEngine;

public class BuildManager : MonoBehaviour {

    private TurretCostsInfo turretToBuild; // it contains the info for buy and sell the turret
    public static BuildManager instance;
    public GameObject buildSTEffect;
    public GameObject buildMLEffect;
    public GameObject buildLTEffect;

    private void Awake()
    {
        instance = this;
    }

    public TurretCostsInfo GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(TurretCostsInfo turret)
    {
        turretToBuild = turret;
    }

    private GameObject ChooseBuildEffect() // it is used for choos the correct build effect looking the tag of the turretToBuild
    {
        string tag = turretToBuild.element.tag;
        if (tag.Equals("ST"))
            return buildSTEffect;
        else if (tag.Equals("ML"))
            return buildMLEffect;
        else
            return buildLTEffect; // <--- need the laser turret!!
    }

    public void BuildTurretOnNode(Node node)
    {
        if (PlayerStatistic.money >= turretToBuild.cost)
        {
            PlayerStatistic.money = PlayerStatistic.money - turretToBuild.cost;
            node.turret = Instantiate(turretToBuild.element, node.GetBuildingPosition(), Quaternion.identity);
            GameObject buildEffect = Instantiate(ChooseBuildEffect(), node.GetBuildingPosition(), Quaternion.identity);
            Destroy(buildEffect, 1f);
            Debug.Log("Your money are " + PlayerStatistic.money);
        }
        else
            Debug.Log("Player doesn't have enough money for build this turret");
    }

    public bool CanBuild(Node node) // you can build only if there is a torret to build and if you have enought money and if the node has not turret yet
    {
        if (turretToBuild != null && (PlayerStatistic.money - turretToBuild.cost >= 0) && node.turret == null)

            return true;
        else
            return false;
    }

}
