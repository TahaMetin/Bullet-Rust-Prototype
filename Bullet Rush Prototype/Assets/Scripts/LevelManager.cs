using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]GameObject player;
    [SerializeField] List<LevelData> levelDatas = new List<LevelData>();
    int currentLevel = -1;
    public void NextLevel()
    {
        if(currentLevel < levelDatas.Count-1)
            currentLevel++;
        player.transform.position = levelDatas[currentLevel].playerPosition;
        SpawnEnemys(levelDatas[currentLevel]);
        ProgressBar.Instance.SetMaxEnemyCount();
    }

    public void RestartLevel()
    {
        SpawnEnemys(levelDatas[currentLevel]);
        player.transform.position = levelDatas[currentLevel].playerPosition;
        ProgressBar.Instance.SetMaxEnemyCount();
    }

    private void SpawnEnemys(LevelData levelData)
    {
        for (int i = 0; i < levelData.spawnPoints.Count; i++)
        {
            for (int j = 0; j < levelData.amounts[currentLevel]; j++)
            {
                //spawn like a square
                float sqrt = Mathf.Sqrt(levelData.amounts[currentLevel]);
                ++sqrt; // add 1 for more straight square 
                Vector3 spawnPoint = levelData.spawnPoints[i];
                spawnPoint = new Vector3(spawnPoint.x + (j%sqrt) * 2, spawnPoint.y, spawnPoint.z + (j/sqrt) * 2);       // multiply with 2 for not spawning intimate ( big enemys scale is 1,5 )
                if (j == 0)
                    PoolManager.Instance.SpawnFromPool("BigEnemy", spawnPoint);
                else
                    PoolManager.Instance.SpawnFromPool("SimpleEnemy", spawnPoint);
            }
        }
        // TODO: spawn enemys next to each other
    }

}
