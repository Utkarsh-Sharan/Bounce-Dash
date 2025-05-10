using ObjectPool;

namespace Obstacle
{
    public class ObstacleService
    {
        private ObstaclePool _obstaclePool;
        private ObstacleScriptableObject _obstacleSO;

        public ObstacleService(ObstacleScriptableObject obstacleSO)
        {
            _obstacleSO = obstacleSO;
            _obstaclePool = new ObstaclePool(obstacleSO);

            SpawnObstacles();
        }

        private void SpawnObstacles()
        {
            ObstacleController spawnedObstacle = _obstaclePool.GetObstacle();
            spawnedObstacle.Configure(_obstacleSO.ObstacleMoveSpeed, _obstacleSO.ObstacleRotationSpeed);
        }

        public void ReturnObstacleToPool(ObstacleController obstacle) => _obstaclePool.ReturnItem(obstacle);
    }
}