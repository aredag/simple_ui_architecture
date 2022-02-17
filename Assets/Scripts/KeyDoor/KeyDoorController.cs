using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    public static KeyDoorController Instance { get; private set; }

    public Dictionary<string, KeyDoorLink> AllDoorKeys { get; } = new Dictionary<string, KeyDoorLink>();

    void Awake()
    {
        Instance = this;
    }
}
