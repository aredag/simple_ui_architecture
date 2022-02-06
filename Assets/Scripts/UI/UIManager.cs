using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

#region Data

    [SerializeField] UIPanelsIndex _uiPanelsIndex;

#endregion

#region UIPanels

    [SerializeField] MainMenuUIPanel _mainMenuUIPanel;
    [SerializeField] OptionsUIPanel _optionsUIPanel;
    [SerializeField] GraphicSettingsUIPanel _graphicsSettingsUIPanel;
    [SerializeField] InventoryUIPanel _inventoryUIPanel;

#endregion

#region Buttons

    [SerializeField] BaseButton _backButton;

#endregion
    
    public static UIManager Instance = null;
    public Stack<IUIPanel> UIPanelsStack { get; private set; }

    void Awake()
    {
        Init();
        InitButtons();
        Flow();
    }

    void Init()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            UIPanelsStack = new Stack<IUIPanel>();
        }
    }


    void InitButtons()
    {
        _backButton.Init(Back);    
        _mainMenuUIPanel.OptionsButton.Init(OptionsButton_handler);
        _mainMenuUIPanel.InventoryButton.Init(InventoryButton_handler);
        _optionsUIPanel.GraphicsButton.Init(GraphicsButton_handler);
    }

    void Flow()
    {
        _mainMenuUIPanel.Show();
    }

    void Back()
    {
        if(UIPanelsStack.Count == 1) return;
        
        var currentPanel = UIPanelsStack.Pop();
        currentPanel.Hide();

        var previousPanel = UIPanelsStack.Peek();
        previousPanel.Show();
    }

#region Handlers

    public void OptionsButton_handler()
    {
        _optionsUIPanel.Show();
    }
    
    public void GraphicsButton_handler()
    {
        _graphicsSettingsUIPanel.Show();
    }
    public void InventoryButton_handler()
    {
        _inventoryUIPanel.Show();
    }

#endregion
}
