using UnityEngine;
using UnityEngine.AI;

public abstract class AIBOT : MonoBehaviour {

    public EnemyAIHealth enemyAIHealth;
    public NavMeshAgent agent;
    public BaseState _state;
    public abstract BaseState state{get;set;}

    //DI
    public WaveManager waveManager;
    
    public GameObject target;

    public FollowState followState;

    public InjuerdState injuerdState;
    public AttackState attackState;
    public AIAnimations AIAnimation;
    public int damage = 1;
    public abstract void Follow();
    public abstract void Attack();
    public abstract void Injuerd();

    public virtual void DestroyOnDie(){;
        waveManager.RemoveDiedEnemyAI(this.gameObject);
        Destroy(this.gameObject);
        
    }
}
