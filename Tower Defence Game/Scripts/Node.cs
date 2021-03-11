using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Selection:")]
    public Color hoverColor;
    private Color defaultColor;
    private Renderer rend;

    [Header("Optional:")]
    public GameObject turret;

    [Header("Positioning:")]
    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
            //To-do: Display this on screen
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
