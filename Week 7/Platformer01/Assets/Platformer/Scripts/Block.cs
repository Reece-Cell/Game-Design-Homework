using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public Camera camera;
    public GameObject coin;

    private AudioSource aud;
    public AudioClip ding;
// Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Block"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
                else if (hitInfo.collider.gameObject.CompareTag("QuestionBlock"))
                {
                    Master.Globals.coins++;
                    Vector3 bar = transform.position;
                    bar.y += 5;
                    
                    Instantiate(coin, bar, Quaternion.identity);
                }
            }
        }
    }
}