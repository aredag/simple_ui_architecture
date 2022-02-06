using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseButton : MonoBehaviour
{
    Button _button;

    public void Init(Action onClickButton)
    {
       _button = GetComponent<Button>();
       _button.onClick.AddListener(() => onClickButton?.Invoke()); 
    }
}
