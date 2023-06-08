using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public UnityEvent<Vector3, Vector3> Fire;
    public int speed = 5;
    [SerializeField] private LayerMask mouseTargetLayerMask = 1 << 6;

    private Rigidbody rb;
    private Vector3 mousePosition = new(0, 0, 0);
    private Vector3 mouseLook = new(0, 0, 0);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        var position = value.Get<Vector2>();
        rb.velocity = new Vector3(speed * position.x, 0, speed * position.y);
    }

    public void OnLook(InputValue value)
    {
        var direction = value.Get<Vector2>();
        var ray = Camera.main.ScreenPointToRay(direction);
        if (Physics.Raycast(ray, out var hitinfo, 1000f, mouseTargetLayerMask, QueryTriggerInteraction.Ignore))
        {
            mousePosition.x = hitinfo.point.x;
            mousePosition.y = transform.position.y;
            mousePosition.z = hitinfo.point.z;
            mouseLook.x = hitinfo.point.x - transform.position.x;
            mouseLook.y = transform.position.y;
            mouseLook.z = hitinfo.point.z - transform.position.z;
            transform.rotation = Quaternion.LookRotation(mouseLook);
        }
    }

    public void OnFire()
    {
        Fire.Invoke(transform.position, mousePosition);
    }

    public void Update()
    {
        mouseLook.x = mousePosition.x - transform.position.x;
        mouseLook.z = mousePosition.z - transform.position.z;
        transform.rotation = Quaternion.LookRotation(mouseLook);
    }

}