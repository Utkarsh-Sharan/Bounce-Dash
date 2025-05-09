using UnityEngine;
using UnityEngine.InputSystem;
using Constant;

namespace Input
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputActions;

        public InputAction MoveAction { get; private set; }

        private void OnEnable()
        {
            _inputActions.FindActionMap(Constants.PLAYER).Enable();
        }

        private void OnDisable()
        {
            _inputActions.FindActionMap(Constants.PLAYER).Disable();
        }

        private void Awake()
        {
            MoveAction = InputSystem.actions.FindAction(Constants.PLAYER_MOVE);
        }
    }
}