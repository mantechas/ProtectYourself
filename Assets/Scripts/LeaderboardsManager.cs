using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardsManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreHolder;
    [SerializeField] private GameObject scoreObject;
    [SerializeField] private GameObject defaultText;
    // Start is called before the first frame update
    void Start()
    {
        var leaderboard = GameManager.Instance.GetTopScores();
        leaderboard.attempt = leaderboard.attempt.OrderByDescending(attempt => attempt.score).ToList();
        int counter = 0;
        if(leaderboard.attempt.Count > 0)
        {
            defaultText.SetActive(false);
        }
        foreach(var score in leaderboard.attempt)
        {
            counter++;
            var createdScore = Instantiate(scoreObject, scoreHolder.transform);
            createdScore.GetComponent<LeaderboardScore>().SetText("NR: "+ counter +"; Time: " + score.time + "; Score: " + score.score);
            if (counter >= 10)
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
