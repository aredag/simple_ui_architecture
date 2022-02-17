using System;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{
  [SerializeField] KeyDoorIDSO _keyDoorIdso;
  [SerializeField] Animator _doorAnimator;

  KeyDoorLink _keyDoorLink;
  
  static readonly int Open = Animator.StringToHash("Open");

  void Start()
  {
      Init();
  }

  void Init()
  {
      _keyDoorLink = new KeyDoorLink(_keyDoorIdso.ID, this, null);
      _keyDoorIdso.OnTryOpenDoor += OpenDoor;
      
      KeyDoorController.Instance.AllDoorKeys.Add(_keyDoorIdso.ID, _keyDoorLink);
  }
  
  void OpenDoor()
  {
      if (_keyDoorLink.Key)
      {
        _doorAnimator.SetTrigger(Open);    
      }
  }

  void OnTriggerEnter(Collider other)
  {
      if (other.gameObject.CompareTag("Player"))
      {
        OpenDoor(); 
      }
  }

  void OnDestroy()
  {
      _keyDoorIdso.OnTryOpenDoor -= OpenDoor;
  }
}
