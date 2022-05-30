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

    public GameObject standartTurrentPrefab;
    void Start()
    {
        turrentToBuild = standartTurrentPrefab;
    }
    private GameObject turrentToBuild;

    public GameObject GetTurrentToBuild()
    {
        return turrentToBuild;
    }
}
