using UnityEngine;

public class MainMenuUIPanel : BaseUIPanel
{
    [SerializeField] BaseButton _optionsButton;
    [SerializeField] BaseButton _inventoryButton;

    public BaseButton OptionsButton => _optionsButton;
    public BaseButton InventoryButton => _inventoryButton;
    
    public override void Show()
    {
        base.Show();
        Debug.Log("Showing Main Menu Panel");
    }


}
