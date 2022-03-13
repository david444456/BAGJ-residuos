using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isCarryingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCarryingHash = Animator.StringToHash("isCarrying");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isCarrying = animator.GetBool(isCarryingHash);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        Vector3 mover = new Vector3(horizontal, 0, vertical);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Backflip");
        }

        if (Input.GetKeyDown(KeyCode.E) && !isCarrying)
        {
            animator.SetBool(isCarryingHash, true);
        }            
        else if (Input.GetKeyDown(KeyCode.E) && isCarrying)
        {
            animator.SetBool(isCarryingHash, false);
        }            

        if (!isWalking && mover != Vector3.zero)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && mover == Vector3.zero)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if(!isRunning && (mover != Vector3.zero && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (mover == Vector3.zero || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

    }
}
