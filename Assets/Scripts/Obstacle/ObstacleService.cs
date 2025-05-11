using UnityEngine;
using ObjectPool;
using Event;

namespace Obstacle
{
    public class ObstacleService
    {
        private ObstaclePool _obstaclePool;
        private ObstacleScriptableObject _obstacleSO;

        private bool _isGameOver = false;
        private float _spawnTimer;
        private float _currentSpawnRate;

        public ObstacleService(ObstacleScriptableObject obstacleSO)
        {
            EventService.Instance.OnPlayerDeathEvent.Addlistener(GameOver);

            _obstacleSO = obstacleSO;
            _obstaclePool = new ObstaclePool(_obstacleSO);

            _currentSpawnRate = _obstacleSO.ObstacleSpawnRate;
            _spawnTimer = 0f;
        }

        public void Update()
        {
            if (!_isGameOver)
            {
                _spawnTimer += Time.deltaTime;
                if (_spawnTimer >= _currentSpawnRate)
                {
                    SpawnObstacles();
                    _spawnTimer = 0;
                }
            }
        }

        private void SpawnObstacles()
        {
            ObstacleController spawnedObstacle = _obstaclePool.GetObstacle();
            spawnedObstacle.Configure(_obstacleSO.ObstacleMoveSpeed, _obstacleSO.ObstacleRotationSpeed);
        }

        public void ReturnObstacleToPool(ObstacleController obstacle) => _obstaclePool.ReturnItem(obstacle);

        private void GameOver() => _isGameOver = true;

        ~ObstacleService()
        {
            EventService.Instance.OnPlayerDeathEvent.RemoveListener(GameOver);
        }
    }
}