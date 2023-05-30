using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;

public class PawnBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static NavMeshAgent _agent;

    public static bool _Patrolling = true;

    public int health;

    public UnityEngine.GameObject _projectile;

    public float deAggroTime, deAggroRange, scanRange;

    private int currentWeapon = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override Node SetupTree()
    {

        Node root = new Selector(new List<Node>
        {
            /*new Selector(new List<Node>
            {
                    new Attack(transform,_projectile),
                }),*/
             
            new Sequence(new List<Node>
            {
                new Scan(transform,deAggroTime,deAggroRange,scanRange),
                new GoToTarget(transform),

            }),

            new TaskPatrol(transform, waypoints),
        }); ;

        return root;

    }
}
