using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    enum EnemyState { STARTING, WANDERING, TRACKING, CHARGING, HITING, STUNNED, KNOCKBACK, DEATH };
    EnemyState enemyState;
    Rigidbody2D rb;
    int enemySpeed = 3;
    [SerializeField] GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyState = EnemyState.STARTING;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(enemyState)
        {
            case EnemyState.STARTING:
                
                break;
        }
    }
}
