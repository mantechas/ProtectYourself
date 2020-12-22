using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModels : MonoBehaviour
{
    [Serializable]
    public class ScoreModel
    {
        public string time;
        public int score;
    }

    [Serializable]
    public class Leaderboard
    {
        public List<ScoreModel> attempt = new List<ScoreModel>();
    }
}
