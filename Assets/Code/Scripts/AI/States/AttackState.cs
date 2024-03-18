using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackState : BaseState
{
    Vector3 LastTargetPos;
    public AttackState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }
    private GameObject AgentTarget;
    public override void enter(){
        AgentTarget = agentScript.target;
        agentScript.AIAnimation.AttackAnimation();
    }

    public override void fixedUpdate(){
        LastTargetPos = AgentTarget.transform.position;
        var Distance = Vector3.Distance(agentScript.transform.position, LastTargetPos);
        if (Distance > Agent.stoppingDistance){
            agentScript.Follow();
        }else{
            agentScript.transform.LookAt(AgentTarget.transform.position);
        }
    }
    public override void update(){

    }


    public override void exit(){
        AgentTarget = null;
        agentScript.AIAnimation.StopAttackAnimation();
    }

    
}