using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Scan : Node
{
    private Transform _transform;
    private float _deAggroTime, _deAggroRange, _scanRange;
    private GameObject _equipWeapon;

    public Scan(Transform transform, float deAggroTime, float deAggroRange, float scanRange, GameObject equipWeapon)
    {
        _transform = transform;
        _deAggroTime = deAggroTime;
        _deAggroRange = deAggroRange;
        _scanRange = scanRange;
        _equipWeapon = equipWeapon;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Scan");
        Transform t = (Transform)GetData("target");
        if (t == null)
        {
            if (_equipWeapon == null)
            {
                Collider[] collidersWeapon = Physics.OverlapSphere(_transform.position, _scanRange, LayerMask.GetMask("WeaponPickup"));
                if (collidersWeapon.Length > 0)
                {
                    parent.parent.SetData("target", collidersWeapon[0].transform);
                    state = NodeState.SUCCESS;
                    return state;
                }
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, _scanRange, LayerMask.GetMask("Player"));
                if (colliders.Length > 0)
                {
                    _equipWeapon.GetComponent<AIWeapon>().fire = true;
                    parent.parent.SetData("target", colliders[0].transform);
                    state = NodeState.SUCCESS;
                    return state;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
        else if (Physics.Linecast(_transform.position, t.position, LayerMask.GetMask("Terrain")) || Vector3.Distance(_transform.position, t.position) > _deAggroRange)
        {
            Debug.Log("IGNORE");
            _equipWeapon.GetComponent<AIWeapon>().fire = false;
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
