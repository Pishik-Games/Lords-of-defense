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
        agentScript.AIAnimation.FollowAnimation();
    }

    public override void fixedUpdate(){
        if (Agent == null || agentScript == null)
        {
            Debug.Log("Agent or agentScript is null");
        }
        if (Agent.stoppingDistance < Vector3.Distance(
            LastPositionTarget,
                Target.transform.position)){
            LastPositionTarget = Target.transform.position;
            Follow(LastPositionTarget);
        }else if (Agent.remainingDistance <= Agent.stoppingDistance){
            agentScript.Attack();
        }
        
    }
    public override void update(){

    }


    public override void exit(){
        Target = null;
        agentScript.AIAnimation.StopFollowAnimation();
    }

    
    public void Follow(Vector3 TargetPosition){
        Agent.SetDestination(TargetPosition);
    }
}