using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataModels;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private Leaderboard topScores = new Leaderboard();
    private int currentScore = 0;
    private int lastTryScore = 0;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadData();
    }

    public Leaderboard GetTopScores()
    {
        return topScores;
    }

    public int GetLastAttempt()
    {
        return lastTryScore;
    }

    public void StartGame()
    {
    }

    public void SetScore(int score)
    {
        currentScore = score;
    }

    public void FinishGame()
    {
        ScoreModel score = new ScoreModel() { time = DateTime.Now.ToString(), score = currentScore };
        topScores.attempt.Add(score);
        SaveData();
        lastTryScore = currentScore;
        currentScore = -1;
        SceneManager.LoadScene("Death");
    }

    private void SaveData()
    {
        try
        {
            string path = Path.Combine(Application.dataPath, "data.json");
            string jsonString = JsonUtility.ToJson(topScores, true);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(jsonString);
            writer.Close();
        }
        catch(Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    private void LoadData()
    {
        try
        {
            Leaderboard scores = new Leaderboard();
            string path = Path.Combine(Application.dataPath, "data.json");
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            reader.Close();
            JsonUtility.FromJsonOverwrite(jsonString, scores);
            topScores = scores;
            Debug.Log("Done");
        }
        catch(Exception e)
        {
            Debug.LogWarning(e);
        }
    }

}
