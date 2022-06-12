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

    public GameObject turrentBuildEffect;
    public NodeUI nodeUI;
    public GameObject turrentLevel_1;
    public GameObject turrentLevel_2;
    public GameObject turrentLevel_3;
    public GameObject mageTower;
    private TurrentBlueprint turrentToBuild;
    private Node selectedNode;
    private TurrentBlueprint selectedTurrent;

    public bool CanBuild {set { } get { return turrentToBuild != null; } }
    
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }
    public void BuildTurrentOn(Node node)
    {
        if (PlayerStats.Money < turrentToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        if (selectedNode != null)
        {
            return;
        }
       
        //if (selectedTurrent != null || selectedTurrent == turrentToBuild)
        //{
        //    selectedTurrent = turrentToBuild;
        //}
        PlayerStats.Money -= turrentToBuild.cost;
        
        GameObject buildEffect = (GameObject)Instantiate(turrentBuildEffect, node.GetBuildPosition(), Quaternion.identity);
        GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turrent = turrent;
        node.turrent.SetActive(false);
        Destroy(buildEffect, 8f);
        StartCoroutine(BuildDelay(8, node));
        Debug.Log("Turrent Build! Money left: " + PlayerStats.Money);
    }
    IEnumerator BuildDelay(float delayTime, Node node)
    {
        yield return new WaitForSeconds(delayTime);
        node.turrent.SetActive(true);
    }
    public void SelectNode (Node node)
    {
        if (selectedNode == node || node.turrent.active == false)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turrentToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurrentToBuild(TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
        DeselectNode();
    }
}
