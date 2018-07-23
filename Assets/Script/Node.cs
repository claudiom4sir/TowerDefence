using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color onMouseEnterColor;
    private Renderer localRenderer;
    private Color startColor;
    public GameObject turret;  // the turret up this node
    private bool isUpgraded = false; // it is used for test if the turret is upgraded yet
    public Vector3 offSet;  // is the offset for put the turret really up this node
    private BuildManager buildManager;

    [HideInInspector]
    public TurretCostsInfo turretCostsInfo; // it is used for store the turret costs info for update/sell current turret


    private void Start()
    {
        buildManager = BuildManager.instance;
        localRenderer = GetComponent<Renderer>();
        startColor = localRenderer.material.color;
    }

    public Vector3 GetBuildingPosition() // it is used for find immediatly the position where build
    {
        return transform.position + offSet;
    }

    private void OnMouseDown() // it is used for create a new turret up the this node, or shows the update/sell pannel
    {
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject()) // check if there is one turret selected in Build Manager and if the mouse is over Shop
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }

    public bool GetIsUpgraded()
    {
        return isUpgraded;
    }

    private void BuildTurret(TurretCostsInfo turretInfo)
    {
        if (buildManager.CanBuild(this))
        {
            PlayerStatistic.money = PlayerStatistic.money - turretInfo.buildCost;
            turretCostsInfo = turretInfo;
            turret = Instantiate(turretInfo.prefab, GetBuildingPosition(), Quaternion.identity);
            GameObject buildEffect = Instantiate(buildManager.ChooseBuildEffect(), GetBuildingPosition(), Quaternion.identity);
            Destroy(buildEffect, 1f);
        }
        else
            Debug.Log("You can't build the turret here");
    }

    public void SellTurretOnNode()
    {
        PlayerStatistic.money = PlayerStatistic.money + turretCostsInfo.sellCost;
        Destroy(turret);
        turretCostsInfo = null;
        GameObject sellEffect = Instantiate(buildManager.sellEffect, GetBuildingPosition(), Quaternion.identity);
        Destroy(sellEffect, 1f);
    }

    public void UpgradeTurretOnNode()
    {
        if (buildManager.CanUpdate(this))
        {
            PlayerStatistic.money = PlayerStatistic.money - turretCostsInfo.upgradeCost;
            isUpgraded = true;  // for don' allow to re-update the turret
            turret.transform.localScale = turret.transform.localScale * 1.25f;
            Turret _turret = turret.GetComponentInChildren<Turret>();
            _turret.Upgrade(_turret);
        }
        else
            Debug.Log("You can't upgrade the turret");
    }

    private void OnMouseEnter() // it is used when mouse enter in this node
    {
        if (turret != null)
            return;
        if (buildManager.CanBuild(this) && !EventSystem.current.IsPointerOverGameObject())
            localRenderer.material.color = onMouseEnterColor;
        TurretCostsInfo turrectSelected = buildManager.GetTurretToBuild();
        if (turrectSelected != null && (PlayerStatistic.money - turrectSelected.buildCost < 0)) // if you have enought money, the node's color became red
            localRenderer.material.color = Color.red;
    }

    private void OnMouseExit () // it is used when mouse exit out this node
    {
        localRenderer.material.color = startColor;
    } 

}
