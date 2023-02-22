using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float elapsedTime = 0f;
    public int startTime = 100;
    public GameObject textTime;
    private const int endTime = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textTime.GetComponent<TextMeshProUGUI>().text = "Time\n" + startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {
            startTime -= 1;
            elapsedTime = 0f;
            textTime.GetComponent<TextMeshProUGUI>().text = "TIME\n" + startTime.ToString();
        }
        else if (startTime == endTime)
        {
            Reset();
            textTime.GetComponent<TextMeshProUGUI>().text = "TIME\n" + startTime.ToString();
        }
    }

    private void Reset()
    {
        startTime = 100;
    }
}
