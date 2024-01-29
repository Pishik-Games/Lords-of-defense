using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackState : BaseState
{
    Vector3 LastTargetPos;
    public AttackState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }
    public GameObject Target;

    public override void enter(){
        Target = GameObject.Find("Player").gameObject;
        agentScript.AIAnimation.AttackAnimation();
    }

    public override void fixedUpdate(){
        LastTargetPos = Target.transform.position;
        var Distance = Vector3.Distance(agentScript.transform.position, LastTargetPos);
        if (Distance > Agent.stoppingDistance){
            agentScript.Follow();
        }else{
            agentScript.transform.LookAt(Target.transform.position);
        }
    }
    public override void update(){

    }


    public override void exit(){
        Target = null;
        agentScript.AIAnimation.StopAttackAnimation();
    }

    
}