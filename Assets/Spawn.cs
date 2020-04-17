using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    void Start()
    {
        enemy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-14f, 14);
            randY = Random.Range(-7, 11);
            whereToSpawn = new Vector2(randX, randY);
            GameObject mechant = Instantiate(enemy, whereToSpawn, Quaternion.identity) as GameObject;
            mechant.GetComponent<Follow>().player = player;

        }
    }
}
