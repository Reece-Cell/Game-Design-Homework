using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Powerup2 : MonoBehaviour
 {
     private AudioSource powerup;
     // Start is called before the first frame update
     void Start()
     {
         
     }
 
     // Update is called once per frame
     void Update () 
     {
         if (GoalMaster.Globals.LScore == 3)
         {
             transform.position = new Vector3(0f, 0f, -25f);
             Debug.Log("Powerup Waking up from Lscore 1");
         }
 
         if (GoalMaster.Globals.LScore == 6)
         {
             transform.position = new Vector3(0f, 0f, -25f);
             Debug.Log("Powerup Waking up from Lscore 2");
         }
     }
     
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name != "Ball") return;
         Debug.Log(this.name + " used");
         powerup.Play();
         transform.position = new Vector3(-50f, 0f, -15f);
     }
 }