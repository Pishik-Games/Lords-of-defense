using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AIBOT , ITouchable {

    public Material HitMatrial;
    public override BaseState state { 
        get {
            return _state; 
        }          
        set {
            try{
                _state.exit();
            }catch{}
            _state = value;
            _state.enter();
        }   
    }

    public void Awake(){
        enemyAIHealth = gameObject.AddComponent<EnemyAIHealth>();
        enemyAIHealth.SetEnemyAIScript(this);
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        AIAnimation = gameObject.AddComponent<AIAnimations>();
    }
    public void Start() {
        Follow();
    }


    public void FixedUpdate() {
        if (state != null){
            if (target)
                state.fixedUpdate(); 
        }else{
        }
    }

    public override void Attack(){
        if (this.attackState != null){
            state = attackState;
        }else{
            var _AttackState = new AttackState(agent);
            attackState = _AttackState;
            state = attackState;
        }
    }

    public override void Follow(){
        if (this.followState != null){
            state = followState;
        }else{
            var _FollowState = new FollowState(agent);
            followState = _FollowState;
            state = followState;
        }
    }

    public override void Injuerd(){
        if (this.injuerdState != null){
            state = injuerdState;
        }else{
            var _InjuerdState = new InjuerdState(agent);
            injuerdState = _InjuerdState;
            state = injuerdState;
        }
    }
    
    // public void OnTriggerEnter(Collider other) {
    // }

    // Its called by Attack Animation Event
    public void AttackAnimationHit(){ 
        if (Vector3.Distance(transform.position,target.transform.position) <= agent.stoppingDistance)
            target.GetComponent<Health>().OnHit(damage);
        

    }

    public void Die(){
        this.DestroyOnDie();
    }

    public void OnTouch(){
        Debug.Log("Touche");
        AutoFireProjectile.SetPlayerTarget(this.gameObject);
    }

    // public override void OnHit(){
    //     HitEffect._instance.HitReaction(GetComponentInChildren<SkinnedMeshRenderer>(),HitMatrial);
    // }
}

/* 
TODO note 
    If collide with Player State = Attack 
    If Collide With Projectille State = Injured
*/
