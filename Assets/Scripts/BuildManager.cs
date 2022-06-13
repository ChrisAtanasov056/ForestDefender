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
    public GameObject demolishEffect;
    public NodeUI nodeUI;
    private TurrentBlueprint turrentToBuild;
    private Node selectedNode;

    public bool CanBuild {set { } get { return turrentToBuild != null; } }
    
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }
    
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
    public TurrentBlueprint GetTurrentBlueprint()
    {
        return turrentToBuild;
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
