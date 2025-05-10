using UnityEngine;

namespace Obstacle
{
    public class RotatingSpikeController : ObstacleController
    {
        private RotatingSpikeView _rotatingSpikeView;

        public RotatingSpikeController(ObstacleView obstacleView) : base()
        {
            _rotatingSpikeView = (RotatingSpikeView)Object.Instantiate(obstacleView);
            _rotatingSpikeView.Initialize(this);
        }

        public override void MoveSpike()
        {
            base.MoveSpike();
            RotateSpike();
        }

        private void RotateSpike()
        {
            Quaternion rotatation = Quaternion.Euler(0f, 0f, 90f * Time.fixedDeltaTime);
            _rotatingSpikeView.GetObstacleBody().MoveRotation(rotatation);
        }
    }
}