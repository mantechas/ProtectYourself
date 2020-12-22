using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        if(score != null)
            score.text = "Your score:" + GameManager.Instance.GetLastAttempt().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
