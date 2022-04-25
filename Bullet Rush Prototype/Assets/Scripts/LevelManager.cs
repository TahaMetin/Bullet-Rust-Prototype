using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]GameObject player;
    [SerializeField] List<LevelData> levelDatas = new List<LevelData>();
    int _currentLevel = -1;
    ProgressBar _progressBar;
    private void Start()
    {
        _progressBar = ProgressBar.Instance;
    }
    public void NextLevel()
    {
        if(_currentLevel < levelDatas.Count-1)
            _currentLevel++;
        player.transform.position = levelDatas[_currentLevel].playerPosition;
        SpawnEnemys(levelDatas[_currentLevel]);
    }

    public void RestartLevel()
    {
        player.transform.position = levelDatas[_currentLevel].playerPosition;
        SpawnEnemys(levelDatas[_currentLevel]);
    }

    private void SpawnEnemys(LevelData levelData)
    {
        for (int i = 0; i < levelData.spawnPoints.Count; i++)
        {
            for (int j = 0; j < levelData.amounts[_currentLevel]; j++)
            {
                //spawn like a square
                float sqrt = Mathf.Sqrt(levelData.amounts[_currentLevel]);
                ++sqrt; // add 1 for more straight square 
                Vector3 spawnPoint = levelData.spawnPoints[i];
                spawnPoint = new Vector3(spawnPoint.x + (j%sqrt) * 2, spawnPoint.y, spawnPoint.z + (j/sqrt) * 2);       // multiply with 2 for not spawning intimate ( big enemy's scale is 1,5 )
                if (j == 0)
                    PoolManager.Instance.SpawnFromPool("BigEnemy", spawnPoint);
                else
                    PoolManager.Instance.SpawnFromPool("SimpleEnemy", spawnPoint);
            }
        }
        _progressBar.SetMaxEnemyCount();
    }
}
