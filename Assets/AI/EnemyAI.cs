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
    }
    public void Start() {
        Follow();
    }


    public void FixedUpdate() {
        if (State != null)
            State.fixedUpdate(); 
    }

    public override void Attack(){
        Debug.Log("Attack");
    }

    public override void Follow(){
        var FollowState = new FollowState(Agent);
        State = FollowState;
        Debug.Log("Follow");
    }

    public override void Injuerd(){
        
        Debug.Log("Injuerd");
    }
}

/* 
TODO note 
    If collide with Player State = Attack 
    If Collide With Projectille State = Injured
*/
