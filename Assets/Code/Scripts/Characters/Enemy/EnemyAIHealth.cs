using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHealth : Health{

    public EnemyAI enemyAI;
    public void SetEnemyAIScript(EnemyAI _enemyAI){
        enemyAI = _enemyAI;
    }

    public override void OnHit(float damage){
        enemyAI.Injuerd();
        enemyAI.injuerdState.GetHit(damage);

    } 
    
    public override void TakeDamage(float damageCount){
        base.TakeDamage(damageCount);

    }

    public override void Heal(float healthCount){
        base.Heal(healthCount);

    }

    public override void OnDamageHandler(){

    }

    public override void OnHealHandler(){
    }

    public override void OnDieHandler(){
        enemyAI.injuerdState.Die();
    }
    
}
