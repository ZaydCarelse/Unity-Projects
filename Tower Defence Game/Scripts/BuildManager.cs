using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Data:")]
    private TurretInfo turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    [Header("Build Particles:")]
    public GameObject buildEffect;

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
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretInfo GetTurretToBuild()
    {
        return turretToBuild;
    }
}
