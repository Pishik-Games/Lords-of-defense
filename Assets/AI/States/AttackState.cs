using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackState : BaseState
{ 

    public AttackState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }
    public GameObject Target;

    public override void enter(){
        Target = GameObject.Find("Player").gameObject;
        agentScript.AIAnimation.AttackAnimation();
    }

    public override void fixedUpdate(){
        if (Agent.stoppingDistance < Vector3.Distance(
            agentScript.transform.position,
                Target.transform.position)){
            agentScript.Follow();
        }
    }
    public override void update(){

    }


    public override void exit(){
        Target = null;
        agentScript.AIAnimation.StopAttackAnimation();
    }

    
}