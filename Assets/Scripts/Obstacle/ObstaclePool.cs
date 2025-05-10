using Obstacle;

namespace ObjectPool
{
    //This script creates/activates random obstacles.
    public class ObstaclePool : GenericObjectPool<ObstacleController>
    {
        private ObstacleScriptableObject _obstacleSO;

        public ObstaclePool(ObstacleScriptableObject obstacleSO)
        {
            _obstacleSO = obstacleSO;
        }

        public ObstacleController GetObstacle() => GetItem();

        protected override ObstacleController CreateItem()
        {
            return new ObstacleController();
        }
    }
}