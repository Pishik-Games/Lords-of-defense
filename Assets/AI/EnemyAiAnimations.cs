using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIAnimations : MonoBehaviour{
    public Animator animator;

    public void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    public void AttackAnimation(){
        DisabaleAllAnimations();
        animator.SetBool("IsAttacking",true);
    }

    public void StopAttackAnimation(){
        DisabaleAllAnimations();
        animator.SetBool("IsAttacking",false);
    }

    public void FollowAnimation(){
        DisabaleAllAnimations();
        animator.SetBool("isFollowing",true);
    }

    public void StopFollowAnimation(){
        DisabaleAllAnimations();
        animator.SetBool("isFollowing", false);
    }

    private void DisabaleAllAnimations(){
        animator.SetBool("IsAttacking",false);
        animator.SetBool("isFollowing", false);

    }
    
}