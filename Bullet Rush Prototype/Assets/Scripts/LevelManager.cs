using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]GameObject player, enemySpawnPointsGO;
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
        ProgressBar.Instance.SetMaxEnemyCount();
    }

    public void RestartLevel()
    {
        SpawnEnemys(2);
        ProgressBar.Instance.SetMaxEnemyCount();
    }

    private void SpawnEnemys(int amount)
    {
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                if (j == 0)
                    PoolManager.Instance.SpawnFromPool("BigEnemy",enemySpawnPoints[i].position);
                else
                    PoolManager.Instance.SpawnFromPool("SimpleEnemy", enemySpawnPoints[i].position);
            }
        }
        // TODO: spawn enemys next to each other
    }

}
