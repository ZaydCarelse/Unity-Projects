using UnityEngine;

public class NodeUI : MonoBehaviour
{
    [Header("UI:")]
    public GameObject ui;

    [Header("Selection:")]
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
