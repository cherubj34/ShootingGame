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
        // �Ѿ��� �߻�Ǳ� ���� �����. �� �ڵ尡 ������ �Ѿ��� ���ϴ� ���·� ������ �ʴ´�.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = start;
        rb.AddForce(30 * (target - start).normalized, ForceMode.Impulse);
    }
}