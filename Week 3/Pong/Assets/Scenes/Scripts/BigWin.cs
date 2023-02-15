using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWin : MonoBehaviour
{
    public Transform rotationCenter;
    public float radius = 5f;
    public float rotationSpeed = 1f;
    public AudioSource bigwin;
    public bool alive = true;
 
    int randomValue = Random.Range(0, 2);
    // Update is called once per frame
    void Update () 
    {
        int value = (randomValue == 0) ? 5 : -5;

        // Increment angle based on time and speed
        // Calculate new position based on angle and radius
        
        if (GoalMaster.Globals.LScore >= 1 || GoalMaster.Globals.RScore >= 1 && alive == true)
        {
            transform.position = new Vector3(value, 0f, -15f);
        }

    }
     
    private void OnTriggerEnter(Collider other)
    {
        alive = !(alive);
        Debug.Log(this.name + " used");
        if (GoalMaster.Globals.LScore < GoalMaster.Globals.RScore)
        {
            //If Lscore is lower than Right Score, teleport the ball directly into the goal on the Right. Compare again and if equal, both scores become 10.
            other.gameObject.transform.position = new Vector3(0f, 0f, -32.5f);
        }else if (GoalMaster.Globals.RScore < GoalMaster.Globals.LScore)
        {
            other.gameObject.transform.position = new Vector3(0f, 0f, 2.5f);
        }else
        {
            GoalMaster.Globals.RScore = 10;
            GoalMaster.Globals.LScore = 10;
        }
        bigwin.Play();
        transform.position = new Vector3(-50f, 0f, -15f);

    }
}