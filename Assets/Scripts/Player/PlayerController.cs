using UnityEngine;
using UnityEngine.InputSystem;
using Main;

namespace Player
{
    public class PlayerController
    {
        private PlayerView _playerView;
        private InputAction _moveAction;
        private Rigidbody2D _playerRB;
        private PlayerScriptableObject _playerSO;

        private Vector2 _targetPosition;

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
            _playerRB.MovePosition(_targetPosition);
        }

        public void UpdatePlayer()
        {
            Vector2 moveInput = _moveAction.ReadValue<Vector2>();
            float moveAmount = moveInput.x;

            _targetPosition = _playerRB.position + new Vector2(moveAmount * _playerSO.PlayerMoveSpeed * Time.deltaTime, 0f);
        }
    }
}