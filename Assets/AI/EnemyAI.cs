using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AIBOT{
    public override AISTates State { 
        get {
            return _state; 
        }          
        set {   
            _state = value; 
            switch (value){
                case AISTates.Follow:{
                    Follow();
                    break;
                }
                case AISTates.Attack:{
                    Attack();
                    break;
                }
                case AISTates.Injuerd:{
                    Injuerd();
                    break;
                }
            }
        }   
    }

    private Vector3 LastPositionTarget;

    public void Awake() {
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Target = GameObject.Find("Player").gameObject;
    }
    public void Start() {
        State = AISTates.Follow;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate() {

        if (Agent.stoppingDistance < Vector3.Distance(LastPositionTarget, Target.transform.position)){
            State = AISTates.Follow;
            LastPositionTarget = Target.transform.position;
        } 
       
    }
    public static Vector3 PlayerLastPos;

    public override void Attack(){
        Debug.Log("Attack");
    }

    public override void Follow(){
        Agent.SetDestination(Target.transform.position);
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
