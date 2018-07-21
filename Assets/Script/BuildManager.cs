using UnityEngine;

public class BuildManager : MonoBehaviour {

    private TurretCostsInfo turretToBuild; // it contains the info for buy and sell the turret
    private Node selectedNode;
    public static BuildManager instance;
    public GameObject buildSTEffect;
    public GameObject buildMLEffect;
    public GameObject buildLTEffect;
    public NodeUI nodeUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        nodeUI = nodeUI.GetComponent<NodeUI>();
    }

    public TurretCostsInfo GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node) // it is used as a switch, 
            DeselectNode();
        else
        {
            selectedNode = node;
            turretToBuild = null;
            nodeUI.SetTarget(selectedNode);
        }
    }

    private void DeselectNode()
    {
        selectedNode = null;
        nodeUI.SetTarget(null);
    }

    public void SelectTurretToBuild(TurretCostsInfo turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public GameObject ChooseBuildEffect() // it is used for choos the correct build effect looking the tag of the turretToBuild
    {
        string tag = turretToBuild.prefab.tag;
        if (tag.Equals("ST"))
            return buildSTEffect;
        else if (tag.Equals("ML"))
            return buildMLEffect;
        else
            return buildLTEffect;
    }

    public bool CanUpdate(Node node) // it check if you can update the turret on this node
    {
        if (node.turret != null && PlayerStatistic.money - node.turretCostsInfo.upgradeCost >= 0 && !node.GetIsUpgraded())
            return true;
        else
            return false;
    }

    public bool CanBuild(Node node) // you can build only if there is a torret to build and if you have enought money and if the node has not turret yet
    {
        if (turretToBuild != null && (PlayerStatistic.money - turretToBuild.buildCost >= 0) && node.turret == null)
            return true;
        else
            return false;
    }

}
