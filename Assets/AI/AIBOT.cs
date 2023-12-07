using UnityEngine;
using UnityEngine.AI;

public abstract class AIBOT : MonoBehaviour ,HitReaction {
    public NavMeshAgent Agent;
    public BaseState _state;

    public HealthManager healthManager;
    public abstract BaseState State{get;set;}
    public GameObject Target;

    public FollowState followState;

    public InjuerdState InjuerdState;
    public AttackState AttackState;
    public AIAnimations AIAnimation;
    public int damage = 1;
    public abstract void Follow();
    public abstract void Attack();
    public abstract void Injuerd();

    public virtual void DestroyOnDie(){
        Debug.Log(this.gameObject.name+" Died!");
        WaveManager._instance.RemoveSpawnedEnemyAI(this.gameObject);
        Destroy(this.gameObject);
        
    }

    public abstract void OnHit();
}
