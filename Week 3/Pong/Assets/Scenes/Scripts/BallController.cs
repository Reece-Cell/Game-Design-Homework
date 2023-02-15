using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 _direction;

    public float unitspersecond = 1f;

    public AudioSource ping;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this._direction = new Vector3(10f, 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * Time.deltaTime * unitspersecond;
        ping.pitch = unitspersecond - 0.2f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Vector3 magnitude = collision.contacts[0].normal;
        _direction = Vector3.Reflect(_direction, magnitude);
        
        if (collision.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector3(0f, 0.2f, -15f);
            rb.AddForce(new Vector3(0f, 0f, -15f), ForceMode.Acceleration);
            unitspersecond = 1f;
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            if(unitspersecond <= 2f)
            {
                unitspersecond += 0.5f;
            }else if (unitspersecond is > 2f and < 3f)
            {
                unitspersecond += 1f;
            }else if (unitspersecond > 4f)
            {
            }
        }
        if (collision.gameObject.CompareTag("Power"))
        {
            collision.gameObject.transform.position = new Vector3(300f, 0.2f, -15f);
            if (collision.gameObject.name == "PowerSpeed" || collision.gameObject.name == "PowerSpeed2")
            {
                Debug.Log("Speed Boost");
                unitspersecond += 0.5f;
            }
        }
        ping.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            other.gameObject.transform.position = new Vector3(300f, 0.2f, -15f);
            if (other.gameObject.name == "PowerSpeed" || other.gameObject.name == "PowerSpeed2")
            {
                Debug.Log("Speed Boost");
                unitspersecond += 0.5f;
            }
        }
    }
} 
