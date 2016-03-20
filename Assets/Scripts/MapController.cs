using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{

    public List<Enemy> enemies;

    public GameObject smallEnemy;
    public GameObject normalEnemy;
    public GameObject bigEnemy;


    public float SEspawnTime = 3.0f;
    public float BEspawnTime = 5.0f;
    public float NEspawnTime = 10.0f;

    public Transform[] spawns;
    int spawnSize;

    public GameObject player;

    public Effect effect;


    // Use this for initialization
    void Start()
    {
        spawnSize = spawns.Length;
        effect.RandomEffect();
    }

    // Update is called once per frame
    float timeElapsed;
    float maxTime = 1.0f;
    int randomSpawn;
    int randomEnemy;
    void Update()
    {
        randomSpawn = UnityEngine.Random.Range(0, spawnSize - 1);
        randomEnemy = (int)Mathf.Round(Time.time);
        if (timeElapsed > maxTime)
        {
            if (randomEnemy % 3 == 0) SpawnSmall();
            if (randomEnemy % 10 == 0) SpawnBig();
            else
            if (randomEnemy % 5 == 0) SpawnNormal();

            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);
    }

    void SpawnNormal()
    {
        var enemy = (GameObject)Instantiate(normalEnemy, spawns[randomSpawn].position, spawns[randomSpawn].rotation);
        enemies.Add(    enemy.GetComponent< Enemy>());
    }
    void SpawnBig()
    {
        var enemy = (GameObject)Instantiate(bigEnemy, spawns[randomSpawn].position, spawns[randomSpawn].rotation);
        enemies.Add(enemy.GetComponent<Enemy>());
    }
    void SpawnSmall()
    {
        var enemy = (GameObject)Instantiate(smallEnemy, spawns[randomSpawn].position, spawns[randomSpawn].rotation);
        enemies.Add(enemy.GetComponent< Enemy>());
    }
}
