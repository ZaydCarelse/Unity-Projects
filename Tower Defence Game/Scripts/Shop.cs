using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Turrets:")]
    public TurretInfo standardTurret;
    public TurretInfo missileLauncher;
    public TurretInfo laserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void PurchaseAnotherTurret()
    {

    }
}
