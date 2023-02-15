using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private AudioSource powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () 
    {
        if (GoalMaster.Globals.RScore == 3)
        {
            transform.position = new Vector3(0f, 0f, -5f);
        }

        if (GoalMaster.Globals.RScore == 6)
        {
            transform.position = new Vector3(0f, 0f, -5f);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ball") return;
        Debug.Log(this.name + " used");
        powerup.Play();
        transform.position = new Vector3(-50f, 0f, -15f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Ball") return;
        Debug.Log(this.name + " used");
        powerup.Play();
        transform.position = new Vector3(-50f, 0f, -15f);
    }
}
