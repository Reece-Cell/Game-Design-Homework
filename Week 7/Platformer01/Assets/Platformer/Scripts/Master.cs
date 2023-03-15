using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Master : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public static class  Globals
    {
        public static int coins = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.GetComponent<TextMeshProUGUI>().text = "Coins\n" + Master.Globals.coins.ToString();
    }
}
