using ObjectPool;

namespace Obstacle
{
    public class ObstacleService
    {
        private ObstaclePool _obstaclePool;

        public ObstacleService(ObstacleScriptableObject obstacleSO)
        {
            _obstaclePool = new ObstaclePool(obstacleSO);
        }
    }
}