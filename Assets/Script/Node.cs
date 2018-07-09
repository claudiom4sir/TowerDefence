using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color onMouseEnterColor;
    private Renderer localRenderer;
    private Color startColor;
    private GameObject turret;  // the turret up this node
    public Vector3 offSet;  // is the offset for put the turret really up this node

    void Start()
    {
        localRenderer = GetComponent<Renderer>();
        startColor = localRenderer.material.color;
    }

    void OnMouseDown() // it is used for create a new turret up the this node
    {
        if (BuildManager.instance.TurretToBuild() != null && !EventSystem.current.IsPointerOverGameObject()) // check if there is one turret selected in Build Manager and if the mouse is over Shop
        {
            if (turret != null) //because you cant create more then one turret up this node
                Debug.Log("Can't create a turret, turret already exists");
            else
                turret = Instantiate(BuildManager.instance.TurretToBuild(), transform.position + offSet, transform.rotation);
        }
    }

    void OnMouseEnter() // it is used when mouse enter in this node
    {
        if (BuildManager.instance.TurretToBuild() != null && !EventSystem.current.IsPointerOverGameObject())
        {
            localRenderer.material.color = onMouseEnterColor;
        }
        
    }

    void OnMouseExit () // it is used when mouse exit out this node
    {
        localRenderer.material.color = startColor;
    } 

}
