using UnityEngine;

public class Node : MonoBehaviour {

    public Color onMouseEnterColor;
    private Renderer localRenderer;
    private Color startColor;
    private GameObject turret;  // the turret up this node
    public BuildManager buildManager;
    public Vector3 offSet;  // is the offset for put the turret really up this node

    void Start()
    {
        localRenderer = GetComponent<Renderer>();
        startColor = localRenderer.material.color;
    }

    void OnMouseDown() // it is used for create a new turret up the this node
    {
        if (turret != null) //because you cant create more then one turret up this node
            Debug.Log("Can't create a turret, turret already exists");
        else
            turret = Instantiate(buildManager.TurretToBuild(), transform.position + offSet, transform.rotation);
    }

    void OnMouseEnter() // it is used when mouse enter in this node
    {
        localRenderer.material.color = onMouseEnterColor;
    }

    void OnMouseExit () // it is used when mouse exit out this node
    {
        localRenderer.material.color = startColor;
    }

}
