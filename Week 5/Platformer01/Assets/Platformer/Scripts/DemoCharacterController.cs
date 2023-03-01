using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCharacterController : MonoBehaviour
{
    public float acceleration = 100f;

    public float maxSpeed = 8f;

    public float jumpForce = 10f;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;

        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y + 0.03f;
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down,2 );

        rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed), rbody.velocity.y, rbody.velocity.z);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (isGrounded == true)
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * halfHeight, Color.red, 0f, false);
        }
        if (isGrounded == false)
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * halfHeight, Color.green, 0f, false);
            rbody.AddForce(Vector3.down * 7.5f, ForceMode.Acceleration);
        }

        float speed = rbody.velocity.magnitude;
        GetComponent<Animator>().SetFloat("Speed", speed);
    }
}
