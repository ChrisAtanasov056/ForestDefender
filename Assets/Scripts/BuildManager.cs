using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene");
        }
        instance = this;
    }

    public GameObject turrentLevel_1;
    public GameObject turrentLevel_2;
    public GameObject turrentLevel_3;

    private TurrentBlueprint turrentToBuild;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public void BuildTurrentOn(Node node)
    {
        if (PlayerStats.Money < turrentToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.Money -= turrentToBuild.cost;
        GameObject turrent =(GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turrent = turrent;
        Debug.Log("Turrent Build! Money left: " + PlayerStats.Money);
    }
    public void SelectTurrentToBuild(TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
    }
}
