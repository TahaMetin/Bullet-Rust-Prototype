using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]GameObject pfBigEnemy, pfSimpleEnemy;
    GameObject player, enemySpawnPointsGO;
    List<Transform> enemySpawnPoints;
    private void Awake()
    {
        player = GameObject.Find("Player");
        enemySpawnPointsGO = GameObject.Find("Enemy Spawn Points");
        
    }
    private void Start()
    {
        enemySpawnPoints = new List<Transform>();
        for (int i = 0; i < enemySpawnPointsGO.transform.childCount; i++)
        {
            enemySpawnPoints.Add(enemySpawnPointsGO.transform.GetChild(i).transform);
        }
    }
    public void NextLevel()
    {
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j == 0)
                    Instantiate(pfBigEnemy, enemySpawnPoints[i]);
                Instantiate(pfSimpleEnemy, enemySpawnPoints[i]);
            }
        }
    }

    public void RestartLevel()
    {
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j == 0)
                    Instantiate(pfBigEnemy, enemySpawnPoints[i]);
                Instantiate(pfSimpleEnemy, enemySpawnPoints[i]);
            }
        }
    }
}
