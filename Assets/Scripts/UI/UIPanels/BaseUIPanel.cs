using UnityEngine;

public class BaseUIPanel : MonoBehaviour, IUIPanel
{
    public virtual void Show()
    {
        if (!UIManager.Instance.UIPanelsStack.Contains(this))
        {
            if (UIManager.Instance.UIPanelsStack.Count > 0)
            {
                var previousPanel = UIManager.Instance.UIPanelsStack.Peek();
                previousPanel?.Hide();
            }

            UIManager.Instance.UIPanelsStack.Push(this);
        }
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
