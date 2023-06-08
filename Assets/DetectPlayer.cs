using UnityEngine;
using UnityEngine.Events;

public class DetectPlayer : MonoBehaviour
{
    public UnityEvent<Vector3> Detect;
    private void OnTriggerStay(Collider other)
    {
        Detect.Invoke(other.transform.position);
    }
}
