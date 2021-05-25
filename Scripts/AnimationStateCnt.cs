using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateCnt : MonoBehaviour
{
    Animator animator;
    int isRunningHash;// is for better performance
    int isJumpingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
         
    }

    
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardpress = Input.GetKey("w");

        if (!isRunning && forwardpress)
        {
            animator.SetBool(isRunningHash, true);   
        }
        if (isRunning && !forwardpress)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private void FixedUpdate()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool Space = Input.GetKey(KeyCode.Space);


        if (  Space)
        {
            animator.SetBool(isJumpingHash, true);
        }
        if (!Space  )
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
