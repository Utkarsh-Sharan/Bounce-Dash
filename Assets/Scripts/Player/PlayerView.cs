using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRB;

        private PlayerController _playerController;

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void FixedUpdate()
        {
            _playerController.FixedUpdatePlayer();
        }

        private void Update()
        {
            _playerController.UpdatePlayer();
        }

        public Rigidbody2D GetPlayerBody() => _playerRB;
    }
}