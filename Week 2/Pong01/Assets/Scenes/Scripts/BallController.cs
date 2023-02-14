using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 _direction;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this._direction = new Vector3(10f, 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 magnitude = collision.contacts[0].normal;
        _direction = Vector3.Reflect(_direction, magnitude);
        
        if (collision.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector3(0f, 0f, -15f);
        }
    }
} 
