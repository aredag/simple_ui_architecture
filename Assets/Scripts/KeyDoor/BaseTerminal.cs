using UnityEngine;
using UnityEngine.UI;

public class BaseTerminal : MonoBehaviour
{
    [SerializeField] KeyDoorIDSO _keyDoorIdso;
    [SerializeField] Button _terminalButton;

    void Start()
    {
        _terminalButton.gameObject.SetActive(false);
    }

    void OpenDoorThroughTerminal()
    {
        _keyDoorIdso.OnTryOpenDoor?.Invoke();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _terminalButton.onClick.AddListener(OpenDoorThroughTerminal); 
            _terminalButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _terminalButton.onClick.RemoveAllListeners();
            _terminalButton.gameObject.SetActive(false);
        }
    }
}