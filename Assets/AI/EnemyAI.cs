using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AIBOT {

    public Material HitMatrial;
    public override BaseState State { 
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

    public void Awake() {
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        AIAnimation = gameObject.AddComponent<AIAnimations>();
        healthManager = gameObject.AddComponent<HealthManager>();
    }
    public void Start() {
        Follow();
    }


    public void FixedUpdate() {
        if (State != null){
            State.fixedUpdate(); 
        }else{
        }
    }

    public override void Attack(){
        if (this.AttackState != null){
            State = AttackState;
        }else{
            var _AttackState = new AttackState(Agent);
            AttackState = _AttackState;
            State = AttackState;
        }
    }

    public override void Follow(){
        if (this.followState != null){
            State = followState;
        }else{
            var _FollowState = new FollowState(Agent);
            followState = _FollowState;
            State = followState;
        }
    }

    public override void Injuerd(){
        if (this.InjuerdState != null){
            State = InjuerdState;
        }else{
            var _InjuerdState = new InjuerdState(Agent);
            InjuerdState = _InjuerdState;
            State = InjuerdState;
        }
    }
    
    // public void OnTriggerEnter(Collider other) {
    // }

    public void AttackAnimationHit(){ // call by Attack Animation
        Debug.Log("AttackAnimationHit");
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (Vector3.Distance(transform.position,Target.transform.position) <= Agent.stoppingDistance){
            Target.GetComponent<Player>().OnHit();
            Debug.Log("attack Damage Deliverd");
            
        }

    }

    public override void OnHit(){
        HitEffect._instance.HitReaction(GetComponentInChildren<SkinnedMeshRenderer>(),HitMatrial);
    }
}

/* 
TODO note 
    If collide with Player State = Attack 
    If Collide With Projectille State = Injured
*/
