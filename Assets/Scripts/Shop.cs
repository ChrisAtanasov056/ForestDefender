using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurrentBlueprint turrentLevel_1;
    public TurrentBlueprint turrentLevel_2;
    public TurrentBlueprint turrentLevel_3;
    public TurrentBlueprint mageTower;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectTowerLevel_1()
    {
        buildManager.SelectTurrentToBuild(turrentLevel_1);
    }
    public void SelectTowerLevel_2()
    {
        buildManager.SelectTurrentToBuild(turrentLevel_2);
    }
    public void SelectTowerLevel_3()
    {
        buildManager.SelectTurrentToBuild(turrentLevel_3);
    }
    public void SelectMageTower()
    {
        buildManager.SelectTurrentToBuild(mageTower);
    }
}
