using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyAboutToBeDestroyed += EnemyOnOnEnemyAboutToBeDestroyed; 
    }

    private void EnemyOnOnEnemyAboutToBeDestroyed()
    {
        Debug.Log("Received Event about Telling Score"); 
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
