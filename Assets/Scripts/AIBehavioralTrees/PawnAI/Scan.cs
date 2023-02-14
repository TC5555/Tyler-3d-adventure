using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Scan : Node
{
    private Transform _transform;

    public Scan(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, PawnBT.scanRange, LayerMask.GetMask("Player"));

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }


            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
