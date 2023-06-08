using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FireBullet(Vector3 start, Vector3 target)
    {
        // 총알이 발사되기 전에 멈춘다. 이 코드가 없으면 총알이 원하는 형태로 나가지 않는다.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = start;
        rb.AddForce(30 * (target - start).normalized, ForceMode.Impulse);
    }
}