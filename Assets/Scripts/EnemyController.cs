using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] GameObject Enemy;
    [SerializeField] Score ScoreManager;

    private GameObject SpawnedEnemy;
    private int enemyCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnedEnemy == null)
        {
            ScoreManager.AddScore();
            SpawnedEnemy = Instantiate(Enemy, spawnPoints[Random.Range(0, spawnPoints.Count)]);
            var enemyCode = SpawnedEnemy.GetComponentInChildren<Enemy>();
            enemyCode.SetSpeed(enemyCounter);
            enemyCounter++;
        }
    }
}
