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

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }


    public override NodeState Evaluate()
    {
        Debug.Log("Patrol");

        if (!PawnBT._Patrolling)
        {
           if(Vector3.Distance(_transform.position, PawnBT._agent.destination) < 2f){
                PawnBT._Patrolling = true;
            }
            state = NodeState.FAILURE;
            return state;
        }
        
            if (_waiting)
            {
                _waitTimer -= Time.deltaTime;
                if (_waitTimer <= 0)
                {
                    _waiting = false;
                }
            }
            else
            { 
                
             
                Transform wp = _waypoints[_currentWaypointIndex];
                if (Vector3.Distance(_transform.position, wp.position) < 2f)
                {
                    _waitTimer = _waitCooldown;
                    _waiting = true;

                    _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                }
                else
                {
                    PawnBT._agent.destination = wp.position;
                    _transform.LookAt(new Vector3(_transform.position.x, wp.position.y, _transform.position.x));
                }
            
        }
        state = NodeState.RUNNING;
        return state;
    }
}
