using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        //bool forwardPressed = Input.GetKey("w");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool runPressed = Input.GetKey("left shift");

        if(horizontal != 0 || vertical != 0)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if ((horizontal == 0 || vertical == 0) && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if((horizontal == 0 || vertical == 0) && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}
