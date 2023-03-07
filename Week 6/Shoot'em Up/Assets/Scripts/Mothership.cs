using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienCommands
{
    //False is left, True is right
    public static float HorizontalDirection = -1f;
    public static int points = 0;
    public static int hiscore = 0;
}

public class Mothership : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy prefab to spawn
    public int rows = 4; // the number of rows of enemies
    public int columns = 8; // the number of columns of enemies
    public float spacing = 1.5f; // the spacing between enemies

    public TextMeshProUGUI Score;
    public TextMeshProUGUI hiscore;
    void Start()
    {
        // Finding the center of the grid
        Vector3 centerPosition = transform.position;
        centerPosition.x -= (columns - 1) * spacing / 2f;
        centerPosition.y += (rows - 1) * spacing / 2f;

        // instantiate the enemy grid using nested loops
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 position = centerPosition;
                position.x += column * spacing;
                position.y -= row * spacing;

                GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        if (AlienCommands.points > AlienCommands.hiscore)
        {
            PlayerPrefs.SetInt("hiscore", AlienCommands.hiscore);
        }
        Score.text = "SCORE \n" + AlienCommands.points.ToString().PadLeft(4, '0');
        hiscore.text = "HI-SCORE \n" + PlayerPrefs.GetInt("hiscore", 0).ToString().PadLeft(4, '0');
    }
}

