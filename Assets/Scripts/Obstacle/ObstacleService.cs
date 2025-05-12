using ObjectPool.Obstacle;

namespace Obstacle
{
    public class ObstacleService
    {
        private ObstaclePool _obstaclePool;
        private ObstacleScriptableObject _obstacleSO;

        public ObstacleService(ObstacleScriptableObject obstacleSO)
        {
            _obstacleSO = obstacleSO;
            _obstaclePool = new ObstaclePool(_obstacleSO);
        }

        public void SpawnObstacles()
        {
            ObstacleController spawnedObstacle = _obstaclePool.GetObstacle();
            spawnedObstacle.Configure(_obstacleSO.ObstacleMoveSpeed, _obstacleSO.ObstacleRotationSpeed);
        }

        public void ReturnObstacleToPool(ObstacleController obstacle, ObstacleType type) => _obstaclePool.ReturnObstacle(obstacle, type);
    }
}