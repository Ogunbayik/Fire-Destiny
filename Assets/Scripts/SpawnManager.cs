using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRate;

    private Vector3 randomPosition;
    private int randomPlaceIndex;
    
    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            var randomIndex = Random.Range(0, 3);
            randomPlaceIndex = (int)randomIndex;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = RandomSpawnPoint();

        GameManager.Instance.enemyList.Add(enemy);
    }

    private Vector3 RandomSpawnPoint()
    {
        var minimumX = -8f;
        var maximumX = 8f;
        var minimumZ = -14f;
        var maximumZ = 14f;
        var randomX = Random.Range(minimumX, maximumX);
        var randomZ = Random.Range(minimumZ, maximumZ);
        var positionY = 0f;

        switch(randomPlaceIndex)
        {
            case 0: randomPosition = new Vector3(randomX, positionY, maximumZ);
                break;
            case 1: randomPosition = new Vector3(randomX, positionY, minimumZ);
                break;
            case 2: randomPosition = new Vector3(maximumX, positionY, randomZ);
                break;
            case 3: randomPosition = new Vector3(minimumX, positionY, randomZ);
                break;
        }    

        return randomPosition;
    }

    public void ChangeSpawnRate(float value)
    {
        spawnRate -= value;
    }
}
