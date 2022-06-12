using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverColor;
    public Material notEnoughMoneyColor;
    private Renderer rend;

    private Material startColor;
    [Header("Optinal")]
    public GameObject turrent;
    //private GameObject[] buildings;
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
        buildManager.BuildTurrentOn(this);
        
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
