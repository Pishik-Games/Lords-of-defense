using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Zenject;

public class FollowState : BaseState
{
    public FollowState(NavMeshAgent agent) : base(agent){
        this.Agent = agent;
    }

    private Vector3 LastPositionTarget;
    private static GameObject player ;
    private static GameObject TownHall ;

    public void Awake()
    {
        player =  GameObject.FindObjectOfType<Player>().gameObject;
        TownHall = GameObject.FindObjectOfType<TownHall>().gameObject;
    }

    public override void enter(){
        if(player== null||TownHall == null)
            this.Awake();
        agentScript.target = FindTarget();
        agentScript.AIAnimation.FollowAnimation();
    }

    public override void fixedUpdate(){
        agentScript.target = FindTarget(); // this most be better to not checking Every Frame 
        
        LastPositionTarget = agentScript.target.transform.position;
        var Distance = Vector3.Distance(agentScript.transform.position, LastPositionTarget);
        if (Agent.stoppingDistance >= Distance){
            agentScript.Attack();
        }else{
            Follow(LastPositionTarget);
        }
        
        
    }
    public override void update(){

    }


    public override void exit(){
        agentScript.AIAnimation.StopFollowAnimation();
    }

    
    public void Follow(Vector3 TargetPosition){
        Agent.SetDestination(TargetPosition);
    }


    private GameObject FindTarget(){
        var agentPos = agentScript.transform.position;

        var playerDistance = Vector3.Distance(agentPos, player.transform.position);
        var TownHallDistance = Vector3.Distance(agentPos, TownHall.transform.position);
    
        return (playerDistance < TownHallDistance) ? player : TownHall;
    }
}