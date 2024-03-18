using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour{

    public Animator animator;

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
}   
