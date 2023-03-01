using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public AudioSource bronk;
    private int weakness = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.y < gameObject.transform.position.y && 
            (collision.gameObject.transform.position.x <= gameObject.transform.position.x + 2) && 
            (collision.gameObject.transform.position.x >= gameObject.transform.position.x - 2) && gameObject.CompareTag("Block") == true)
        { 
            bronk.Play();
            Master.Globals.coins += 100;
            Destroy((gameObject));
        }else if (collision.gameObject.CompareTag("Player") &&
                  collision.gameObject.transform.position.y < gameObject.transform.position.y &&
                  (collision.gameObject.transform.position.x <= gameObject.transform.position.x + 2) &&
                  (collision.gameObject.transform.position.x >= gameObject.transform.position.x - 2) &&
                  gameObject.CompareTag("QuestionBlock"))
        {
            Master.Globals.coins += 100;
            weakness--;
            if (weakness == 0)
            {
                Destroy((gameObject));
            }
        }
    }
}
