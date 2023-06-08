using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : MonoBehaviour
{

    [SerializeField] private List<Vector3> _spot;
    [SerializeField] private LayerMask _player;

    [SerializeField] private float _maxDist = 5f;
    [SerializeField] private int _start = -30;
    [SerializeField] private int _end = 30;
    [SerializeField] private int step = 2;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        for (int angle=_start; angle <= _end; angle+=step)
        {
            if (Physics.Raycast(
                transform.position,
                Quaternion.AngleAxis(angle, transform.up) * transform.forward,
                out var hitInfo,
                _maxDist,
                _player
                ))
            {
                OnRayCastHit(hitInfo.point);
            }
            else
            {
                NoRayCastHit();
            }

        }
    }

    public void OnRayCastHit(Vector3 hitPos)
    {
        _agent.destination = hitPos;
    }

    private void NoRayCastHit()
    {
        if (_agent.velocity.x != 0 || _agent.velocity.z != 0) return;
        _agent.destination = _spot[Random.Range(0, _spot.Count)];
    }


}
