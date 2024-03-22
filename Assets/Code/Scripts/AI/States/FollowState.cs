using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Zenject;

public class FollowState : BaseState
{
    public FollowState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }

    private Vector3 LastPositionTarget;
    private static GameObject player ;
    private static GameObject TownHall;
    private GameObject _target;
    private Vector3 _lastTargetPos;
    private float _nextUpdateTime;

    public void Awake()
    {
        player =  GameObject.FindObjectOfType<Player>().gameObject;
        TownHall = GameObject.FindObjectOfType<TownHall>().gameObject;
    }

    public override void enter(){
        if(player== null||TownHall == null)
            this.Awake();
        agentScript.target = FindTarget();
        agentScript.AIAnimation.FollowAnimation();
    }

    public override void fixedUpdate()
    {
        if (Time.time > _nextUpdateTime)
        {
            _target = FindTarget();
            _nextUpdateTime = Time.time + 0.5f; // Adjust the update interval (0.5s in this example)
            if (_target != null)
            {
                var agentPos = agentScript.transform.position;
                var targetPos = _target.transform.position;
                var distanceSqr = (agentPos - targetPos).sqrMagnitude;

                if (distanceSqr <= Agent.stoppingDistance * Agent.stoppingDistance)
                {
                    agentScript.Attack();
                }
                else
                {
                    Follow(targetPos);
                }

                _lastTargetPos = targetPos;
            }
        }
        
    }
    public override void update(){

    }


    public override void exit(){
        agentScript.AIAnimation.StopFollowAnimation();
    }

    
    public void Follow(Vector3 TargetPosition){
        Agent.SetDestination(TargetPosition);
    }


    private GameObject FindTarget(){
        var agentPos = agentScript.transform.position;

        var playerDistance = Vector3.Distance(agentPos, player.transform.position);
        var TownHallDistance = Vector3.Distance(agentPos, TownHall.transform.position);
    
        return (playerDistance < TownHallDistance) ? player : TownHall;
    }
}