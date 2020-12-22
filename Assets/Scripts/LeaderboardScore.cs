using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScore : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string score)
    {
        text.text = score;
    }
}
