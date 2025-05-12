using System.Collections.Generic;
using UnityEngine;
using Obstacle;
using Event;

namespace ObjectPool.Obstacle
{
    //This script creates/activates random obstacles.
    public class ObstaclePool
    {
        private Dictionary<ObstacleType, Queue<ObstacleController>> _obstaclePool;
        private ObstacleScriptableObject _obstacleSO;

        public ObstaclePool(ObstacleScriptableObject obstacleSO)
        {
            _obstacleSO = obstacleSO;
            _obstaclePool = new Dictionary<ObstacleType, Queue<ObstacleController>>();

            foreach (ObstacleData data in _obstacleSO.ObstacleDataList)
            {
                _obstaclePool[data.ObstacleType] = new Queue<ObstacleController>();

                //Pre-instantiate a few of each obstacle type
                for (int i = 0; i < _obstacleSO.InitialObstacleCount; ++i)
                {
                    ObstacleController controller = CreateObstacle(data);
                    controller.DeactivateObject();
                    _obstaclePool[data.ObstacleType].Enqueue(controller);
                }
            }
        }

        public ObstacleController GetObstacle()
        {
            ObstacleType randomType = (ObstacleType)Random.Range(0, _obstaclePool.Keys.Count);

            //Reusing obstacle from pool
            if (_obstaclePool[randomType].Count > 0)
            {
                ObstacleController reusedObstacle = _obstaclePool[randomType].Dequeue();
                reusedObstacle.ActivateObject();

                return reusedObstacle;
            }

            //Creating random obstacle if pool is empty
            ObstacleData obstacleData = _obstacleSO.ObstacleDataList.Find(o => o.ObstacleType == randomType);
            return CreateObstacle(obstacleData);
        }

        public void ReturnObstacle(ObstacleController obstacleController, ObstacleType type)
        {
            obstacleController.DeactivateObject();
            _obstaclePool[type].Enqueue(obstacleController);
        }

        private ObstacleController CreateObstacle(ObstacleData obstacleData)
        {
            ObstacleView obstacleView = Object.Instantiate(obstacleData.ObstacleView, obstacleData.ObstacleSpawnPoint, obstacleData.ObstacleView.transform.rotation);

            switch(obstacleData.ObstacleType)
            {
                case ObstacleType.Left_Side_Spike:
                    return new LeftSideSpikeController(obstacleView, obstacleView.transform.position);

                case ObstacleType.Right_Side_Spike:
                    return new RightSideSpikeController(obstacleView, obstacleView.transform.position);

                case ObstacleType.Rotating_Spike:
                    return new RotatingSpikeController(obstacleView, obstacleView.transform.position);

                default:
                    Debug.LogError("No such Obstacle Type found!");
                    return null;
            }
        }
    }
}