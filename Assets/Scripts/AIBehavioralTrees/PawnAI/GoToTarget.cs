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
            if (PawnBT._agent.destination != target.position)
            {
                Debug.Log("Go");
                PawnBT._agent.destination = target.position;
            }
            // _transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
            //Debug.Log(target.position);
            //_transform.GetChild(1).GetComponent<PawnModel>().updateHead(target.position);
            _transform.GetChild(1).GetComponent<PawnModel>().target = target.position;


        }

        state = NodeState.RUNNING;
        return state;
    }
}
