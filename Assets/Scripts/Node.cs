using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverColor;
    public Material notEnoughMoneyColor;
    private Renderer rend;

    private Material startColor;
    [HideInInspector]
    public GameObject turrent;
    [HideInInspector]
    public TurrentBlueprint turrentBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    public int buildingRadius = 6;
    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
        buildManager = BuildManager.instance;
        Collider[] colliders = Physics.OverlapSphere(transform.position, buildingRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Building"))
            {
                turrent = collider.gameObject;
            }
        }
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material = hoverColor;
        }
        else
        {
            rend.material = notEnoughMoneyColor;
        }
    }
    
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turrent != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurrent(buildManager.GetTurrentBlueprint());
        
    }

    void BuildTurrent(TurrentBlueprint blueprint)
    {
        if (PlayerStats.Money < turrentBlueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        //if (selectedTurrent != null || selectedTurrent == turrentToBuild)
        //{
        //    selectedTurrent = turrentToBuild;
        //}
        PlayerStats.Money -= blueprint.cost;

        GameObject buildEffect = (GameObject)Instantiate(buildManager.turrentBuildEffect, GetBuildPosition(), Quaternion.identity);
        GameObject _turrent = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;
        turrentBlueprint = blueprint;
        turrent.SetActive(false);
        Destroy(buildEffect, 8f);
        StartCoroutine(BuildDelay(8));
        
        Debug.Log("Turrent Build! Money left: " + PlayerStats.Money);
    }
    IEnumerator BuildDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        turrent.SetActive(true);
    }

    public void UpgradeTurrent()
    {
        if (PlayerStats.Money < turrentBlueprint.upgradedCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        //if (selectedTurrent != null || selectedTurrent == turrentToBuild)
        //{
        //    selectedTurrent = turrentToBuild;
        //}
        PlayerStats.Money -= turrentBlueprint.upgradedCost;
        //Destroy old turrent
        
        Destroy(turrent);

        //Make new one
        GameObject buildEffect = (GameObject)Instantiate(buildManager.turrentBuildEffect, GetBuildPosition(), Quaternion.identity);
        GameObject _turrent = (GameObject)Instantiate(turrentBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;
        turrent.SetActive(false);
        Destroy(buildEffect, 8f);
        StartCoroutine(BuildDelay(8));
        isUpgraded = true;
        Debug.Log("Turrent Build! Money left: " + PlayerStats.Money);
    }
    public void SellTurrent()
    {
        PlayerStats.Money += turrentBlueprint.GetSellAmount();
        GameObject demolish = (GameObject)Instantiate(buildManager.demolishEffect, GetBuildPosition(), buildManager.demolishEffect.transform.rotation);
        Destroy(demolish,5f);
        Destroy(turrent);
        turrentBlueprint = null;
    }
    void OnMouseExit()
    {
        rend.material = startColor;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, buildingRadius);

    }
}
