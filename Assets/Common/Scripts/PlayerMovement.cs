using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float velocityWalk = 2.0f;
    [SerializeField] float velocityRun = 4.0f;
    [SerializeField] float rotationSpeed = 720.0f;

    [Header("To fix")]
    [SerializeField] float yMin = 0.25f;

    float velocity = 2.0f;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool runPressed = Input.GetKey("left shift");
        Vector3 mover = new Vector3(horizontal, 0, vertical);
        mover.Normalize();

        if (runPressed)
            velocity = velocityRun;
        else
            velocity = velocityWalk;

        mover *= Time.deltaTime * velocity;

        characterController.Move(mover);

        if (mover != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(mover, Vector3.up);

            characterController.transform.rotation = 
                Quaternion.RotateTowards(characterController.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (transform.position.y > yMin)
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
    }
}
