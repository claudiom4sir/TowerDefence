using UnityEngine;

[System.Serializable]
public class TurretCostsInfo  {

    public GameObject prefab;
    public int buildCost;
    public int upgradeCost;
    public int sellCost;

    public int GetSellCost()
    {
        sellCost = buildCost / 2;
        return sellCost;
    }
}
