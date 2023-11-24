using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIAnimations : MonoBehaviour{
    public Animator animator;

    public void Awake() {
        animator = GetComponent<Animator>();
    }

    public void AttackAnimation(){
        animator.SetBool("IsAttacking",true);
    }

    public void StopAttackAnimation(){
        animator.SetBool("IsAttacking",false);
    }
}