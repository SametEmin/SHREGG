using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public float attackCooldown = 0;
    private float lastAttackTime;
    private bool  isAnimationOver;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void LateUpdate()   
    {
        // Check for attack input (e.g., mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            isAnimationOver = false;
            // Trigger the attack animation to play once
            animator.SetTrigger("sword_swinging");

            // Update the last attack time
            lastAttackTime = Time.time; 
            
        }
        if(isAnimationOver){
                //animator.SetTrigger("animation_end");
            }
        
    }

    void setAnimationOver(){
        //isAnimationOver = true;
        animator.SetTrigger("animation_end");
    }
}