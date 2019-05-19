using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public AudioRandom audioRandom;
    public float secondsToSpawn=3;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy() {
        yield return new WaitForSeconds(secondsToSpawn);
        enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Enemy>().enemySpawner = this;
        TeleportRandomly();
        yield return null;
    }

    public void EnemyDead() {
        audioRandom.transform.position = enemy.transform.position;
        audioRandom.PlayRandom();
        Destroy(enemy);
        StartCoroutine(SpawnEnemy());
    }

    public void TeleportRandomly() {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1.0f);
        float distance = 0.2f * Random.value + 0.75f;
        enemy.transform.localPosition = distance * direction;
    }
}
