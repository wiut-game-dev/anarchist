using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PeasantEnemyBehaviour : MonoBehaviour
{
    public EnemyState state;
    public EnemyVisibility enemyVisibility;
    public EnemyBehave behave;
    public Rigidbody2D rb;



    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(state.MinArea, state.MaxArea);
        float y = Random.Range(state.MinArea, state.MaxArea);

        behave.FindAlly();
        if (enemyVisibility.targetIsVisible && behave.allyIsHere)
        {
            behave.FollowThePlayer();
            state.Activity = EnemyActivity.Chasing;
        }
        else
        {
            behave.Roam(x, y);
            state.Activity = EnemyActivity.Roaming;
        }

    }

    private void FixedUpdate()
    {
        
    }

    

    

    
}
