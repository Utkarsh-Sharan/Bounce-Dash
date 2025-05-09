using UnityEngine;
using UnityEngine.InputSystem;
using Constant;

namespace Input
{
    //This input service works for both mobile and keyboard
    public class InputService : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputActions;

        public InputAction MoveAction { get; private set; } //move action is used by player controller

        private void Awake()
        {
            MoveAction = InputSystem.actions.FindAction(Constants.PLAYER_MOVE);
        }

        private void OnEnable()
        {
            _inputActions.FindActionMap(Constants.PLAYER).Enable();
        }

        private void OnDisable()
        {
            _inputActions.FindActionMap(Constants.PLAYER).Disable();
        }
    }
}