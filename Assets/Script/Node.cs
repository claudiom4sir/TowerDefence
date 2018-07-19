using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color onMouseEnterColor;
    private Renderer localRenderer;
    private Color startColor;
    public GameObject turret;  // the turret up this node
    public Vector3 offSet;  // is the offset for put the turret really up this node
    private BuildManager buildManager;

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
            buildManager.SelectNode(this);
        if (!buildManager.CanBuild(this) || EventSystem.current.IsPointerOverGameObject()) // check if there is one turret selected in Build Manager and if the mouse is over Shop
            return;
        buildManager.BuildTurretOnNode(this);
    }

    private void OnMouseEnter() // it is used when mouse enter in this node
    {
        if (turret != null)
            return;
        if (buildManager.CanBuild(this) && !EventSystem.current.IsPointerOverGameObject())
            localRenderer.material.color = onMouseEnterColor;
        TurretCostsInfo turrectSelected = buildManager.GetTurretToBuild();
        if (turrectSelected != null && (PlayerStatistic.money - turrectSelected.cost < 0)) // if you have enought money, the node's color became red
            localRenderer.material.color = Color.red;
    }

    private void OnMouseExit () // it is used when mouse exit out this node
    {
        localRenderer.material.color = startColor;
    } 

}
