using UnityEngine;

public class NodeUI : MonoBehaviour {

    private Node target;
    public GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
    }

    public void HideNodeUI()
    {
        ui.SetActive(false);
    }

    public void SetTarget (Node _target)
    {
        if (_target == null)
            ui.SetActive(false);
        else
        {
            target = _target;
            transform.position = _target.GetBuildingPosition();
            ui.SetActive(true);
        }
    }

}
