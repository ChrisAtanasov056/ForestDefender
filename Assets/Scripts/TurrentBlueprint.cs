using UnityEngine;

[System.Serializable]

public class TurrentBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradedCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
