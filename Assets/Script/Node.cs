using UnityEngine;

public class Node : MonoBehaviour {

    public Color onMouseEnterColor;
    private Renderer localRenderer;
    private Color startColor;

    void Start()
    {
        localRenderer = GetComponent<Renderer>();
        startColor = localRenderer.material.color;
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
