using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Turrets:")]
    public TurretInfo standardTurret;
    public TurretInfo missileLauncher;

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

    public void PurchaseAnotherTurret()
    {

    }
}
