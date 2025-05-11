using System.Collections.Generic;
using UnityEngine;
using Obstacle;

namespace ObjectPool
{
    //This script creates/activates random obstacles.
    public class ObstaclePool : GenericObjectPool<ObstacleController>
    {
        private Dictionary<ObstacleType, (ObstacleView, Vector3)> _obstacleDictionary;
        private ObstacleScriptableObject _obstacleSO;

        private ObstacleView _obstacleView;
        private Vector3 _spawnPoint;

        public ObstaclePool(ObstacleScriptableObject obstacleSO)
        {
            _obstacleDictionary = new Dictionary<ObstacleType, (ObstacleView, Vector3)>();
            _obstacleSO = obstacleSO;

            foreach (ObstacleData obstacle in _obstacleSO.ObstacleDataList)
                _obstacleDictionary[obstacle.ObstacleType] = (obstacle.ObstacleView, obstacle.ObstacleSpawnPoint);
        }

        public ObstacleController GetObstacle() => GetItem();   //If GetItem() doesn't find any previously deactivated object, it creates a new object.

        protected override ObstacleController CreateItem()
        {
            ObstacleType randomObstacleType = (ObstacleType)Random.Range(0, _obstacleDictionary.Keys.Count);

            switch (randomObstacleType)
            {
                case ObstacleType.Left_Side_Spike:
                    _obstacleView = _obstacleDictionary[ObstacleType.Left_Side_Spike].Item1;
                    _spawnPoint = _obstacleDictionary[ObstacleType.Left_Side_Spike].Item2;

                    return new SpikeController(_obstacleView, _spawnPoint);

                case ObstacleType.Right_Side_Spike:
                    _obstacleView = _obstacleDictionary[ObstacleType.Right_Side_Spike].Item1;
                    _spawnPoint = _obstacleDictionary[ObstacleType.Right_Side_Spike].Item2;

                    return new SpikeController(_obstacleView, _spawnPoint);

                case ObstacleType.Rotating_Spike:
                    _obstacleView = _obstacleDictionary[ObstacleType.Rotating_Spike].Item1;
                    _spawnPoint = _obstacleDictionary[ObstacleType.Rotating_Spike].Item2;

                    return new RotatingSpikeController(_obstacleView, _spawnPoint);

                default:
                    Debug.LogError("No such type of obstacle found!");
                    return null;
            }
        }
    }
}