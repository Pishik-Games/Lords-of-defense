using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AIBOT{
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
    }
    public void Start() {
        Follow();
    }


    public void FixedUpdate() {
        if (State != null){
            State.fixedUpdate(); 
        }else{
            Debug.Log("State is null");
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
        Debug.Log("Attack");
    }

    public override void Follow(){
        if (this.followState != null){
            State = followState;
        }else{
            var _FollowState = new FollowState(Agent);
            followState = _FollowState;
            State = followState;
        }
        Debug.Log("Follow");
    }

    public override void Injuerd(){
        if (this.InjuerdState != null){
            State = InjuerdState;
        }else{
            var _InjuerdState = new InjuerdState(Agent);
            InjuerdState = _InjuerdState;
            State = InjuerdState;
        }
            Debug.Log("Injuerd");
    }
    
    public void OnTriggerEnter(Collider other) {
        var obj = other.transform.gameObject;
        if (obj.tag == "Projectile"){
            Debug.Log("Projectile Trigger");
            Injuerd();
        }    
    }
}

/* 
TODO note 
    If collide with Player State = Attack 
    If Collide With Projectille State = Injured
*/
