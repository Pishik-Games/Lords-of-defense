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

    public override void fixedUpdate()
    {
        var agentPos = agentScript.transform.position;
        var targetPos = AgentTarget.transform.position;
        var distanceSqr = (agentPos - targetPos).sqrMagnitude;

        // Early exit to avoid unnecessary calculations
        if (distanceSqr <= Agent.stoppingDistance * Agent.stoppingDistance)
        {
            agentScript.transform.LookAt(targetPos);
            return;
        }

        agentScript.Follow();
    }
    public override void update(){

    }


    public override void exit(){
        AgentTarget = null;
        agentScript.AIAnimation.StopAttackAnimation();
    }

    
}