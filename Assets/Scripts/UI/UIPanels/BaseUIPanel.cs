using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BaseUIPanel : MonoBehaviour, IUIPanel
{
    CanvasGroup _canvasGroup;

    public virtual void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    public virtual void Show()
    {
        UIManager.Instance.Panel_handler(this);
  
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual async Task<bool> ShowAnimAsync()
    {
        var ts = new TaskCompletionSource<bool>();

        gameObject.SetActive(true);
        UIManager.Instance.Panel_handler(this);
        SetInteractable(false);
        _canvasGroup.DOFade(1f, 2f).OnComplete(delegate
        {
            SetInteractable(true);
            ts.SetResult(true);
        });
        
        await ts.Task;
        
        return true;
    }

    public virtual async Task<bool> HideAnimAsync()
    {
        var ts = new TaskCompletionSource<bool>();
        
        SetInteractable(false);
        _canvasGroup.DOFade(0f, 2f).OnComplete(delegate
        {
            ts.SetResult(true);
            gameObject.SetActive(false);
        });

        await ts.Task;

        return true;
    }

    protected void SetInteractable(bool state)
    {
       _canvasGroup.interactable = state;
    }
}
