using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class InjuerdState : BaseState
{
    public InjuerdState(NavMeshAgent agent , HealthManager healthManager) : base(agent){
        this.Agent = agent;
        this.agentHealthManager = healthManager;
    }
    //public GameObject Target;

    public HealthManager agentHealthManager;

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
        agentHealthManager.Damage(50);
        Debug.Log(agentHealthManager.Health);
        if (agentHealthManager.Health <= 0){
            Debug.Log(agentHealthManager.Health);
            Die();
        }else{
            agentScript.Follow();
        }
    }

    public void Die(){
        agentScript.DestroyOnDie();
    }

    
}