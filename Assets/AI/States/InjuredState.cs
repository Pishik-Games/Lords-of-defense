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
        var agentHealthManager = agentScript.healthManager;
        agentHealthManager.Damage(50);
        Debug.Log(agentHealthManager.Health);
        if (agentHealthManager.Health <= 0){
            Debug.Log(agentHealthManager.Health);
            Die();
        }else{
            agentScript.Follow();
        }
        agentScript.OnHit();
    }

    public void Die(){
        agentScript.DestroyOnDie();
    }

    
}