using UnityEngine;

namespace Obstacle
{
    public class SpikeController : ObstacleController
    {
        private SpikeView _spikeView;

        public SpikeController(ObstacleView obstacleView) : base()
        {
            _spikeView = (SpikeView)Object.Instantiate(obstacleView);
            _spikeView.Initialize(this);
        }
    }
}