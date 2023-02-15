using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

using UnityEngine.AI;

public class PawnBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static NavMeshAgent _agent;

    public UnityEngine.GameObject _projectile;

    public static float scanRange = 6f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override Node SetupTree()
    {

        Node root = new Selector(new List<Node>
        {
            new Attack(transform,_projectile),

            new Sequence(new List<Node>
            {
                new Scan(transform),
                new GoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;

    }
}
