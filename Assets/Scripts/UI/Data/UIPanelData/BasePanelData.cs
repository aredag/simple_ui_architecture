using UnityEngine;

[CreateAssetMenu(fileName = "BasePanelData", menuName = "UIPanels/Panel Data", order = 2)]
public class BasePanelData : ScriptableObject 
{
    [SerializeField] protected GameObject _panelPrefab;
    [SerializeField] protected string _panelID;

    public string PanelID => _panelID;
}
