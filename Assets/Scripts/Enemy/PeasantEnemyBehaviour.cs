using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        behave.FindAlly();
        if (enemyVisibility.targetIsVisible && behave.allyIsHere)
        {
            behave.FollowThePlayer();
        }
        else
        {
            behave.Roam();
        }

    }

    private void FixedUpdate()
    {
        
    }

    

    

    
}
