using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "0_LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject //Store enemy spawn positions, player spawn position and spawn amounts for each level
{
    public Vector3 playerPosition;
    public List<Vector3> spawnPoints = new List<Vector3>();
    public List<int> amounts = new List<int>();
}
