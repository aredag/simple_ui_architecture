using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(typeof(IGrabable), out Component component))
        {
            var grabed = component.GetComponent<IGrabable>();
            grabed.Grab();
        }
    }
}
