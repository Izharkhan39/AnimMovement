using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPP_move : MonoBehaviour
{
    public CharacterController controller;
    public Transform Cam;
    public Transform groundCheck;

    public float smoothTime;
    float  SmoothVelocity;

    public float gravity = 9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed = 12f;
  
    public float jumpHeight = 3f;

    bool isgrounded;
    Vector3 velocity;

    private void FixedUpdate()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isgrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref SmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward; 

            controller.Move(moveDir.normalized * speed * Time. deltaTime);
        }


        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
