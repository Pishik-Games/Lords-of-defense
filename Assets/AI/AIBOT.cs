using UnityEngine;
using UnityEngine.AI;

public abstract class AIBOT : MonoBehaviour{
    public NavMeshAgent Agent;
    public BaseState _state;
    public abstract BaseState State{get;set;}
    public GameObject Target;

    public FollowState followState;

    public InjuerdState InjuerdState;
    public AttackState AttackState;
    public AIAnimations AIAnimation;

    public float health = 100.0f;
    public float damage = 1.0f;
    public abstract void Follow();
    public abstract void Attack();
    public abstract void Injuerd();

    public virtual void DestroyOnDie(){
        Debug.Log(this.gameObject.name+" Died!");
        Destroy(this.gameObject);
    }
}
