using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed();
    private SpriteRenderer spriteRenderer;
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    public int pointValue = 50;
    public float speed = 500f;
    
    private Rigidbody2D rb;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomNum = Random.Range(1, 5);
        switch (randomNum)
        {
            case 1:
                spriteRenderer.color = Color.white;
                break;
            case 2:
                spriteRenderer.color = Color.yellow;
                pointValue += 50;
                break;
            case 3:
                spriteRenderer.color = new Color(1f, 0.7f, 0f);
                pointValue += 100;
                break;
            case 4:
                spriteRenderer.color = new Color(1f, 0.4f, 0f);
                pointValue += 150;

                break;
            default:
                break;
        }
        Debug.Log("Getting rb");
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ouch!");
            if (OnEnemyAboutToBeDestroyed != null)
            {
                OnEnemyAboutToBeDestroyed.Invoke();
            }

            AlienCommands.points += pointValue;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);   
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            AlienCommands.HorizontalDirection *= -1f;
        }
    }

    private void Update()
    {
        Vector3 movement = new Vector3(AlienCommands.HorizontalDirection, 0f, 0f) * speed * Time.deltaTime;
        Debug.Log("Moving");
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
