using System;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject turrentBuildEffect;
    private TurrentBlueprint turrentToBuild;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }
    public void BuildTurrentOn(Node node)
    {
        if (PlayerStats.Money < turrentToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turrentToBuild.cost;
        GameObject buildEffect = (GameObject)Instantiate(turrentBuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 8f);
        StartCoroutine(BuildDelay(8, node));
        Debug.Log("Turrent Build! Money left: " + PlayerStats.Money);
    }
    IEnumerator BuildDelay(float delayTime, Node node)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turrent = turrent;
    }

    public void SelectTurrentToBuild(TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
    }
}
