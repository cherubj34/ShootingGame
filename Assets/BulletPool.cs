using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject Bullet;

    private int _count = 100;
    private List<Bullet> _bullets = new();
    private int _now = 0;

    public void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            _bullets.Add(Instantiate(Bullet).GetComponent<Bullet>());
        }
    }

    public void FireBullet(Vector3 start, Vector3 target)
    {
        _bullets[_now++].FireBullet(start, target);
        if (_now >= _bullets.Count) { _now = 0; }
    }
}