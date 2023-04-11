using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform destination;

    private Enemy enemy;

    void Start() 
    {
        // Find the game object with the name "Destination" and set its transform as the destination
        destination = GameObject.Find("Destination").transform;
    }
    
    void Update()
    {
        // Set the NavMeshAgent's destination to the destination transform
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}