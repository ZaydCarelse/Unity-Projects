using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Data:")]
    private TurretInfo turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Build Manager Duplicated. Deleting other instance.");
            Destroy(gameObject);
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretInfo turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enought Gold!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret built. Money left: " + PlayerStats.Money);
    }
}
