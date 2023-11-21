using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public abstract class BaseState {
    public NavMeshAgent Agent;
    public BaseState(NavMeshAgent agent){
        Agent = agent;
    }
    public abstract void enter();
    public abstract void update();
    public abstract void fixedUpdate();
    public abstract void exit();
}