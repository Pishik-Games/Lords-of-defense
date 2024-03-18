using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class InjuerdState : BaseState{

    private EnemyAIHealth enemyAIHealth;
    public InjuerdState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
        enemyAIHealth = agentScript.enemyAIHealth;

    }
    //public GameObject Target;

    public override void enter(){
        
    }

    public override void fixedUpdate(){
    }
    public override void update(){

    }


    public override void exit(){
        //Target = null;
    }

    public void GetHit(float damage){
        enemyAIHealth.TakeDamage(damage);
    }

    public void Die(){
        agentScript.DestroyOnDie();
    }

    
}