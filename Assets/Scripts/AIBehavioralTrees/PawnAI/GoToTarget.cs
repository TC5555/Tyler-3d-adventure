using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class GoToTarget : Node
{
    private Transform _transform;

    public GoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("GoTo");
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 1f)
        {
            PawnBT._agent.destination = target.position;
            _transform.LookAt(new Vector3(_transform.position.x, target.position.y, _transform.position.x));

        }

        state = NodeState.RUNNING;
        return state;
    }
}
