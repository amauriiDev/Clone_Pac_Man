using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();

    }
    
    public void AnimateMovement(Vector2 value){
        animator.SetFloat("Horizontal", value.x);
        animator.SetFloat("Vertical", value.y);
    }
}
