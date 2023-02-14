using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float unitspersecond = 900f;
    
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal2Value = Input.GetAxis("Horizontal2");
        Vector3 force = Vector3.left * horizontal2Value * unitspersecond * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"We Hit: {collision.gameObject.name}");

        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minY = bounds.min.x;
        
        
        Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);
        Vector3 bounceDirection = rotation * Vector3.up;
        
        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 300f, ForceMode.Acceleration);
    }
}
