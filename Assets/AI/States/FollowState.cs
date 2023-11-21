using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FollowState : BaseState
{

    public FollowState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }
    public GameObject Target;

    private Vector3 LastPositionTarget;

    public override void enter(){
        Target = GameObject.Find("Player").gameObject;
    }

    public override void fixedUpdate(){
        if (Agent.stoppingDistance < Vector3.Distance(
            LastPositionTarget,
                Target.transform.position)){
            LastPositionTarget = Target.transform.position;
            Follow(LastPositionTarget);
        }   
    }
    public override void update(){

    }


    public override void exit(){
        Target = null;
    }

    
    public void Follow(Vector3 TargetPosition){
        Agent.SetDestination(TargetPosition);
    }
}