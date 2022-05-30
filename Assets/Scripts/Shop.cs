using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseTowerLevel_1()
    {
        buildManager.SetTurrentToBuild(buildManager.turrentLevel_1);
    }
    public void PurchaseTowerLevel_2()
    {
        buildManager.SetTurrentToBuild(buildManager.turrentLevel_2);
    }
    public void PurchaseTowerLevel_3()
    {
        buildManager.SetTurrentToBuild(buildManager.turrentLevel_3);
    }
}
