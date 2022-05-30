using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverColor;

    private Renderer rend;

    private Material startColor;

    private GameObject turrent;

    public Vector3 positionOffset;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
    }
    void OnMouseEnter()
    {
        rend.material = hoverColor;

    }
    void OnMouseDown()
    {
        if (turrent != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }
        GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
        turrent =(GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseExit()
    {
        rend.material = startColor;
    }
}
