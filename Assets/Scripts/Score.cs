using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private int score = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
        GameManager.Instance.SetScore(score);
        text.text = score.ToString();
    }
}
