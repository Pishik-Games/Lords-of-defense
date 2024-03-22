using System.Collections;
using System.Collections.Generic;
using ModestTree;
using Unity.VisualScripting;
using UnityEngine.Animations;
using UnityEngine;
using Zenject;

public class PlayerAnimHandler : MonoBehaviour
{

    public Animator animator;

    private AnimationClip AttackClipState;

    [Inject]
    public PlayerAttack playerAttack;
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
        SetUpAttackEvent();

    }

    public void OnAnimationEnd(){
        playerAttack.Shoot();
    }

    public void SetAttackSpeed(float count){
        animator.SetFloat("AttackSpeed", count);
    }

    public bool isAttacking{
        set { 
            animator.SetBool("isAttacking", value);
        }
    }
    public bool isWalking{
        set { 
            animator.SetBool("isWalking", value);
        }
    }    
    private void SetUpAttackEvent(){
        var runtimeAnim = animator.runtimeAnimatorController;

        for (int i = 0; i < runtimeAnim.animationClips.Length; i++)
        {
            if (runtimeAnim.animationClips[i].name == "Attack")
            {
                AttackClipState = runtimeAnim.animationClips[i];

                AnimationEvent animationEvent = new AnimationEvent();
                animationEvent.functionName = "OnAnimationEnd";
                animationEvent.time = 1.0f;


                AttackClipState.AddEvent(animationEvent);
                break;
            }
        }

    }
}   
