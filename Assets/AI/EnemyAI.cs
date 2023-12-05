using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AIBOT{

    public int damage = 1;
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
            var _InjuerdState = new InjuerdState(Agent, healthManager);
            InjuerdState = _InjuerdState;
            State = InjuerdState;
        }
    }
    
    public void OnTriggerEnter(Collider other) {
        var obj = other.transform.gameObject;
        if (obj.tag == "Projectile"){
            Injuerd();
        }    
    }

    public void AttackAnimationHit(){
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (Vector3.Distance(transform.position,Target.transform.position) <= Agent.stoppingDistance){
            Target.GetComponent<HealthManager>().Damage(damage);
            Debug.Log("attack Damage Deliverd");
            
        }

    }
}

/* 
TODO note 
    If collide with Player State = Attack 
    If Collide With Projectille State = Injured
*/
