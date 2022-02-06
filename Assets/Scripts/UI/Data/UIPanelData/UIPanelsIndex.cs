using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UIPanelIndex", menuName = "UIPanels/UIPanelIndex", order = 1)]
public class UIPanelsIndex : ScriptableObject
{
    [SerializeField] BasePanelData[] _allPanelsData;

    public BasePanelData GetPanelByID(string id)
    {
        return _allPanelsData.FirstOrDefault(panel => panel.PanelID == id);
    }
}
