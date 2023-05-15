using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Scan : Node
{
    private Transform _transform;
    private float _deAggroTime, _deAggroRange, _scanRange;


    public Scan(Transform transform,float deAggroTime,float deAggroRange, float scanRange)
    {
        _transform = transform;
        _deAggroTime = deAggroTime;
        _deAggroRange = deAggroRange;
        _scanRange = scanRange;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Scan");
        Transform t = (Transform)GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _scanRange, LayerMask.GetMask("Player"));
            if (colliders.Length > 0)
            {
                _transform.Find("EnemyWeapon").GetComponent<AIWeapon>().fire = true;
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }


            state = NodeState.FAILURE;
            return state;
        }
        else if (Physics.Linecast(_transform.position, t.position, LayerMask.GetMask("Terrain")) || Vector3.Distance(_transform.position, t.position) > _deAggroRange)
        {
            Debug.Log("IGNORE");
            _transform.GetChild(0).GetComponent<AIWeapon>().fire = false;
            parent.parent.ClearData("target");
            state = NodeState.FAILURE;
            PawnBT._Patrolling = false;
            return state;
        }

        _transform.GetChild(0).LookAt(t);

        state = NodeState.SUCCESS;
        return state;
    }

}
