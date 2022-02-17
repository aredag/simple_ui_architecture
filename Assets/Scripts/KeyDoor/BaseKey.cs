using DG.Tweening;
using UnityEngine;

public class BaseKey : MonoBehaviour, IGrabable
{
    [SerializeField] KeyDoorIDSO _keyDoorIdso;

    void AddKey()
    {
        if (KeyDoorController.Instance.AllDoorKeys.ContainsKey(_keyDoorIdso.ID))
        {
            var keyLinkValue = KeyDoorController.Instance.AllDoorKeys[_keyDoorIdso.ID];
            
            if(keyLinkValue.Key) return;
                
            keyLinkValue.Key = this;
            Debug.Log($"{keyLinkValue.ID}|{keyLinkValue.Door}|{keyLinkValue.Key}");
            transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutElastic).
                OnComplete(delegate {gameObject.SetActive(false);});
        }
    }

    public void Grab()
    {
        AddKey();
    }
}