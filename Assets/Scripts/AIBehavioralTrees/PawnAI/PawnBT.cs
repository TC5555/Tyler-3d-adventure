using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

using UnityEngine.AI;

public class PawnBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static NavMeshAgent _agent;

    public static float scanRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override Node SetupTree()
    {

        Node root = new Selector(new List<Node>
        {
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
