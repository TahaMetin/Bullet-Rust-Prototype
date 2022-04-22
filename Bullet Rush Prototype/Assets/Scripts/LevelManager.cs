using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]GameObject pfBigEnemy, pfSimpleEnemy;
    [SerializeField]GameObject player, enemySpawnPointsGO, enemySceneContainer;
    List<Transform> enemySpawnPoints;

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
        SpawnEnemys(2);
    }

    public void RestartLevel()
    {
        SpawnEnemys(2);
    }

    private void SpawnEnemys(int amount)
    {
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                GameObject enemy;
                if (j == 0)
                    enemy= Instantiate(pfBigEnemy, enemySpawnPoints[i]);
                else
                    enemy =Instantiate(pfSimpleEnemy, enemySpawnPoints[i]);
                enemy.transform.parent = enemySceneContainer.transform;
            }
        }
    }
}
