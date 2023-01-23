using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public LevelScriptableObject levelData;
    public GameObject player;
    public List<GameObject> spawnLocations;
    Vector2 spawnArea = new Vector2(3, 3);

    int currentWave = 0;
    float timer;
    private void Update()
    {
        transform.position = player.transform.position;
        timer += Time.deltaTime;
        if (timer >= levelData.waves[currentWave].spawnTime)
        {
            for (int i = 0; i < levelData.waves[currentWave].spawnCount; i++)
            {
                SpawnEnemy();
            }
            timer = 0;
            if(currentWave < levelData.waves.Count - 1)
            {
                currentWave++;
            }
        }
    }

    void SpawnEnemy()
    {
        float randonNumber = Random.Range(0f, 100f);
        List<LevelScriptableObject.Enemies> possibleEnemies = new List<LevelScriptableObject.Enemies>();
        foreach (LevelScriptableObject.Enemies enemy in levelData.waves[currentWave].enemies)
        {
            if (randonNumber <= enemy.spawnRate)
            {
                possibleEnemies.Add(enemy);
            }
        }
        if (possibleEnemies.Count > 0)
        {
            LevelScriptableObject.Enemies drop = possibleEnemies[Random.Range(0, possibleEnemies.Count)];
            Transform location = spawnLocations[Random.Range(0, 4)].transform;
            Instantiate(drop.prefab, new Vector2(Random.Range(location.position.x-spawnArea.x, location.position.x + spawnArea.x), Random.Range(location.position.y - spawnArea.y, location.position.y + spawnArea.y)), Quaternion.identity);
        }
    }
}
