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

    private GameObject turrentToBuild;

    public GameObject GetTurrentToBuild()
    {
        return turrentToBuild;
    }

    public void SetTurrentToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }
}
