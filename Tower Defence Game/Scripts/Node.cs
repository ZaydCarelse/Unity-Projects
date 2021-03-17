using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Selection:")]
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color defaultColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretInfo currentTurretInfo;
    [HideInInspector]
    public bool isUpgraded = false;

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

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
            //To-do: Display this on screen
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    public void BuildTurret(TurretInfo info)
    {
        if (PlayerStats.Money < info.cost)
        {
            Debug.Log("Not enought Gold!");
            return;
        }

        PlayerStats.Money -= info.cost;

        GameObject _turret = (GameObject)Instantiate(info.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        currentTurretInfo = info;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void SellTurret()
    {
        PlayerStats.Money += currentTurretInfo.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        currentTurretInfo = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < currentTurretInfo.upgradeCost)
        {
            Debug.Log("Not enough Gold to upgrade!");
            return;
        }

        PlayerStats.Money -= currentTurretInfo.upgradeCost;

        //Gets rid of the old turret
        Destroy(turret);

        //Builds new turret
        GameObject _turret = (GameObject)Instantiate(currentTurretInfo.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
}
