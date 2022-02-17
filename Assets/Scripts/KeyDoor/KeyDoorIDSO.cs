using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyDoor ID", menuName = "KeyDoor/KeyDoorID", order = 1)]
public class KeyDoorIDSO : ScriptableObject
{
    [SerializeField] string _id;
    public string ID => _id;

    public Action OnTryOpenDoor;
}
