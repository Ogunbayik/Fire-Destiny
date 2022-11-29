using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> enemyList = new List<GameObject>();

    private SpawnManager spawnManager;
    public TextMeshProUGUI gameOverText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    void Update()
    {

    }
    public void GameOver()
    {
        spawnManager.gameObject.SetActive(false);
        

        DestroyAllEnemies();
    }

    private void DestroyAllEnemies()
    {
        float delayTime = 0.5f;
        var enemyCount = (enemyList.Count - 1);

        Destroy(enemyList[enemyCount], delayTime);
    }

}
