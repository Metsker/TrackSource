using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Range(1,10)]
        [SerializeField] private float speed;
    
        private InputMaster _playerInput;
        private Rigidbody _rigidbody;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _playerInput = new InputMaster();
        
            _rigidbody.WakeUp();
            _playerInput.Enable();
        
        }
        private void OnDisable()
        {
            _rigidbody.Sleep();
            _playerInput.Disable();
        }

        private void FixedUpdate()
        {
            MovePlayer(_playerInput.Player.Movement.ReadValue<Vector2>());
        }

        private void MovePlayer(Vector3 direction)
        {
            direction = new Vector3(direction.x, 0, direction.y);
            _rigidbody.AddForce(direction * speed, ForceMode.Force);
        }
    }
}
