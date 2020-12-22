using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform EnemyTransform;
    [SerializeField] private Vector3 TargetPosition;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        EnemyTransform.position = Vector3.MoveTowards(EnemyTransform.position, TargetPosition, step);
    }

    public void SetSpeed(int enemyCount)
    {
        speed = speed + (speed * ((float)enemyCount / 20f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Character"))
        {
            GameManager.Instance.FinishGame();
        }
        else if(collision.collider.tag.Equals("Mask"))
        {
            Destroy(EnemyTransform.gameObject);
        }
    }
}
