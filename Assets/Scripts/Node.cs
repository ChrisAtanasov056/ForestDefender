using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverColor;

    private Renderer rend;

    private Material startColor;

    private GameObject turrent;

    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
        buildManager = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
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
        if (buildManager.GetTurrentToBuild()== null)
        {
            return;
        }
        if (turrent != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }
        GameObject turrentToBuild = buildManager.GetTurrentToBuild();
        turrent =(GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
        rend.material = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material = startColor;
    }
}
