using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalMaster : MonoBehaviour
{
    public TextMeshProUGUI LScoretext;
    public TextMeshProUGUI RScoretext;
    public static class  Globals
    {
        public static int LScore = 0;
        public static int RScore = 0;
    }

    private void Update()
    {
        LScoretext.text = "Score: " + Globals.LScore;
        RScoretext.text = "Score: " + Globals.RScore;
    }
}
