using ObjectPool;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleService
    {
        private ObstaclePool _obstaclePool;
        private ObstacleScriptableObject _obstacleSO;

        private float _spawnTimer;
        private float _currentSpawnRate;

        public ObstacleService(ObstacleScriptableObject obstacleSO)
        {
            _obstacleSO = obstacleSO;
            _obstaclePool = new ObstaclePool(_obstacleSO);

            _currentSpawnRate = _obstacleSO.ObstacleSpawnRate;
            _spawnTimer = _currentSpawnRate;
        }

        public void Update()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0)
            {
                SpawnObstacles();
                _spawnTimer = _currentSpawnRate;
            }
        }

        private void SpawnObstacles()
        {
            ObstacleController spawnedObstacle = _obstaclePool.GetObstacle();
            spawnedObstacle.Configure(_obstacleSO.ObstacleMoveSpeed, _obstacleSO.ObstacleRotationSpeed);
        }

        public void ReturnObstacleToPool(ObstacleController obstacle) => _obstaclePool.ReturnItem(obstacle);
    }
}