using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Data:")]
    private GameObject turretToBuild;
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

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
