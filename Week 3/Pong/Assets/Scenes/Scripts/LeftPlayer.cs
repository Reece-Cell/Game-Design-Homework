using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeftPlayer : MonoBehaviour
{
    public float unitspersecond = 900f;

    // Update is called once per frame
    void Update()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        Vector3 force = Vector3.left * horizontalValue * unitspersecond * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"We Hit: {collision.gameObject.name}");

        BoxCollider bc = GetComponent<BoxCollider>();

        Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);
        Vector3 bounceDirection = rotation * Vector3.up;
        
        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 300f, ForceMode.Acceleration);
    }

}
