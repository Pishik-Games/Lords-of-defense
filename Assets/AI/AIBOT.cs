using UnityEngine;
using UnityEngine.AI;

public abstract class AIBOT : MonoBehaviour{
    public NavMeshAgent Agent;
    public static AISTates _state;
    public abstract AISTates State{get;set;}
    public GameObject Target;
    public abstract void Follow();
    public abstract void Attack();
    public abstract void Injuerd();

    public enum AISTates{
        Follow,
        Attack,
        Injuerd
    }
}
