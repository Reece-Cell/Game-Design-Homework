using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float Speed = 1f;
  public float Move;

  public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      // get the horizontal input axis from the player
      float horizontalInput = Input.GetAxis("Horizontal");

      // calculate the movement vector based on the input axis and speed
      Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * Speed * Time.deltaTime;

      // move the object based on the movement vector
      transform.position += movement;
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }
}
