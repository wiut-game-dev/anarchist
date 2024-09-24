using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] prefab;


    private void Start()
    {
        StartCoroutine(Spawning());
    }



    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        int n = 2;
        while (n > 0)
        {
            yield return wait;
            int rand = Random.Range(0, prefab.Length);
            GameObject enemyToSpawn = prefab[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            n--;
        }
    }
}
