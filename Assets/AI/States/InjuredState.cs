using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class InjuerdState : BaseState
{

    public InjuerdState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }
    //public GameObject Target;

    public override void enter(){
      //  Target = GameObject.Find("Player").gameObject;
        GetHit();
    }

    public override void fixedUpdate(){
    }
    public override void update(){

    }


    public override void exit(){
        //Target = null;
    }

    public void GetHit(){
        agentScript.health -= 50.0f;
        Debug.Log(agentScript.health);
        if (agentScript.health <= 0){
            Debug.Log(agentScript.health);
            Die();
        }else{
            agentScript.Follow();
        }
    }

    public void Die(){
        agentScript.DestroyOnDie();
    }

    
}