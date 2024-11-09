using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float MinRangeOfSpawn;
    public float MaxRangeOfSpawn;
    public GameObject Enemy;
    public float CurrentTime;
    public float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime > SpawnTime)
        {
            Instantiate(Enemy, new Vector2(Random.Range(MinRangeOfSpawn, MaxRangeOfSpawn), Random.Range(MinRangeOfSpawn, MaxRangeOfSpawn)), Quaternion.identity);
            CurrentTime = 0;
        }
    }
}
