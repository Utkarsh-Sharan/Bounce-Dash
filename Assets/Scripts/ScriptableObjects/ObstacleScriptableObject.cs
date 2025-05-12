using UnityEngine;
using System.Collections.Generic;
using Obstacle;

[CreateAssetMenu(fileName = "ObstacleScriptableObject", menuName = "Scriptable Objects/ObstacleScriptableObject")]
public class ObstacleScriptableObject : ScriptableObject
{
    public List<ObstacleData> ObstacleDataList;
    public float ObstacleSpawnRate;
    public float ObstacleMoveSpeed;
    public float ObstacleRotationSpeed;
    public int ObstacleCount;
}

[System.Serializable]
public struct ObstacleData
{
    public ObstacleType ObstacleType;
    public ObstacleView ObstacleView;
    public Vector3 ObstacleSpawnPoint;
}

public enum ObstacleType
{
    Left_Side_Spike,
    Right_Side_Spike,
    Rotating_Spike,
}