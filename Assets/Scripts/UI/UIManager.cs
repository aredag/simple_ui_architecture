using System.Collections.Generic;
using System.Threading;
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

        var panelsArray = new BaseUIPanel[]
        {
           _mainMenuUIPanel,
           _optionsUIPanel,
           _inventoryUIPanel,
           _graphicsSettingsUIPanel
        };

        foreach (var panel in panelsArray)
        {
           panel.Init(); 
        }

    }


    void InitButtons()
    {
        _backButton.Init(Back);    
        _mainMenuUIPanel.OptionsButton.Init(OptionsButton_handler);
        _mainMenuUIPanel.InventoryButton.Init(InventoryButton_handler);
        _optionsUIPanel.GraphicsButton.Init(GraphicsButton_handler);
        HideUnhideBackButton();
    }

    async void Flow()
    {
        await _mainMenuUIPanel.ShowAnimAsync();
    }

    async void Back()
    {
        if (UIPanelsStack.Count == 1) return;
        
        var currentPanel = UIPanelsStack.Pop();
        await currentPanel.HideAnimAsync();

        var previousPanel = UIPanelsStack.Peek();
        await previousPanel.ShowAnimAsync();
    }

#region Handlers

    public async void OptionsButton_handler()
    {
        await _optionsUIPanel.ShowAnimAsync();
    }
    
    public async void GraphicsButton_handler()
    {
        await _graphicsSettingsUIPanel.ShowAnimAsync();
    }
    public async void InventoryButton_handler()
    {
        await _inventoryUIPanel.ShowAnimAsync();
        
    }


    public void Panel_handler(BaseUIPanel _panel)
    {
        if (!Instance.UIPanelsStack.Contains(_panel))
        {
            if (Instance.UIPanelsStack.Count > 0)
            {
                var previousPanel = UIManager.Instance.UIPanelsStack.Peek();
                previousPanel?.HideAnimAsync();
            }

            Instance.UIPanelsStack.Push(_panel);
        }

        HideUnhideBackButton();
    }

    void HideUnhideBackButton()
    {
        _backButton.gameObject.SetActive(UIPanelsStack.Count != 1);
    }

#endregion
}
