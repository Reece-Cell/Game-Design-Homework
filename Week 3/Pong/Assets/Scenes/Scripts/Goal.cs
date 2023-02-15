using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (this.gameObject.name == "Goal West")
            {
                GoalMaster.Globals.LScore += 1;
                Debug.Log($"Left Player is scored on! Score is now: {GoalMaster.Globals.LScore} to {GoalMaster.Globals.RScore}");
            }
            else
            {
                GoalMaster.Globals.RScore += 1;
                Debug.Log($"Right Player is scored on! Score is now: {GoalMaster.Globals.LScore} to {GoalMaster.Globals.RScore}");
            }

            if (GoalMaster.Globals.RScore == 11)
            {
                Debug.Log($"Right Player has gotten 11 points! They win! Resetting!");
                GoalMaster.Globals.LScore = 0;
                GoalMaster.Globals.RScore = 0;
            }else if (GoalMaster.Globals.LScore == 11)
            {
                Debug.Log($"Left Player has gotten 11 points! They win! Resetting!");
                GoalMaster.Globals.LScore = 0;
                GoalMaster.Globals.RScore = 0;
            }
        }
    }
}
