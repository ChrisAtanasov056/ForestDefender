using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverColor;

    private Renderer rend;

    private Material startColor;
    [Header("Optinal")]
    public GameObject turrent;

    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
        buildManager = BuildManager.instance;
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
        rend.material = hoverColor;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turrent != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }
        buildManager.BuildTurrentOn(this);
        rend.material = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material = startColor;
    }
}
