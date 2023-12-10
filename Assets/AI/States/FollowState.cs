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
            return;
        }
        LastPositionTarget = Target.transform.position;
        var Distance = Vector3.Distance(agentScript.transform.position, LastPositionTarget);
        if (Agent.stoppingDistance >= Distance){
            agentScript.Attack();
        }else{
            Follow(LastPositionTarget);
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