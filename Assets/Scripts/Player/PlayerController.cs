using UnityEngine;
using UnityEngine.InputSystem;
using Main;
using Obstacle;
using Event;

namespace Player
{
    //Following MVC architecture.
    //Model is handled by scriptable object.
    public class PlayerController
    {
        private PlayerView _playerView;
        private InputAction _moveAction;
        private Rigidbody2D _playerRB;
        private PlayerScriptableObject _playerSO;

        private float _moveAmount;

        public PlayerController(PlayerScriptableObject playerSO)
        {
            _playerSO = playerSO;

            _playerView = Object.Instantiate(_playerSO.PlayerView, _playerSO.SpawnPosition, Quaternion.identity);
            _playerView.Initialize(this);

            _moveAction = GameService.Instance.GetInputService().MoveAction;

            _playerRB = _playerView.GetPlayerBody();
        }

        public void FixedUpdatePlayer()
        {
            _playerRB.linearVelocity = new Vector2(_moveAmount * _playerSO.PlayerMoveSpeed, _playerRB.linearVelocity.y);
        }

        public void UpdatePlayer()
        {
            Vector2 moveInput = _moveAction.ReadValue<Vector2>();
            _moveAmount = moveInput.x;
        }

        public void HandlePlayerObstacleCollision(GameObject otherObject)
        {
            if (otherObject.GetComponent<ObstacleView>())
            {
                EventService.Instance.OnPlayerDeathEvent.InvokeEvent();
                _playerView.gameObject.SetActive(false);
            }
        }
    }
}