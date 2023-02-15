using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Attack : Node
{
    private Transform _transform;

    private GameObject _projectile;

    public Attack(Transform transform, GameObject projectile)
    {
        _transform = transform;
        _projectile = projectile;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target != null)
        {
            if (Physics.Linecast(_transform.position, target.position, LayerMask.GetMask("Terrain")))
            {
                Debug.Log("attack");
                Vector3 shootAngle = _transform.forward;

                GameObject projectileObject = PawnBT.Instantiate(_projectile, _transform.position, Quaternion.Euler(shootAngle));
                Projectile projectile = projectileObject.GetComponent<Projectile>();
                projectile.Launch(shootAngle, _transform.position);

            }
        }
        
        state = NodeState.FAILURE;
        return state;
    }
}
