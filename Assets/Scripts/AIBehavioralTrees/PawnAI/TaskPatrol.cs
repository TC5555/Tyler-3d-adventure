using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


using BehaviorTree;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    private float _waitTimer;
    private float _waitCooldown = 1f;
    private bool _waiting = false;

    private NavMeshAgent _agent;

    public TaskPatrol(Transform transform, Transform[] waypoints, NavMeshAgent agent)
    {
        _agent = agent;
        _transform = transform;
        _waypoints = waypoints;
    }


    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitTimer -= Time.deltaTime;
            if(_waitTimer <= 0)
            {
                _waiting = false;
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];

            if (Mathf.Approximately(Vector3.Distance(_transform.position, wp.position), 0.0f))
            {
                _transform.position = wp.position;
                _waitTimer = _waitCooldown;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _agent.destination = wp.position;
                _transform.LookAt(wp.position);
            }

        }
        state = NodeState.RUNNING;
        return state;
    }
}
