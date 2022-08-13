using UnityEngine;

namespace gtools.Controller
{
    public class AnyDirMovement : MonoBehaviour
    {
        [SerializeField] private bool canBeControlled;
        [SerializeField] private Axis axis;
        [SerializeField] private string horizontalAxis, verticalAxis;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform lookForward;
        
        private Vector2 _inputDirection;
        private void FixedUpdate()
        {
            InputMovement();

            if (!(_inputDirection.magnitude > 0)) return;
            
            if (_inputDirection.magnitude > 1)
                _inputDirection = _inputDirection.normalized;

            var direction = new Vector3(0, 0, 0);

            switch ((int)axis)
            {
                case 0:
                    direction = new Vector3(_inputDirection.x, _inputDirection.y, 0);
                    
                    if (lookForward != null)
                        lookForward.up = direction;
                    
                    break;
                case 1:
                    direction = new Vector3(_inputDirection.x, 0,_inputDirection.y);
                    
                    if (lookForward != null)
                        lookForward.forward = direction;
                    
                    break;
            }
            
            transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);

            
        }

        private void InputMovement()
        {
            if (canBeControlled)
            {
                _inputDirection = new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis));
            }
        }
        
        private enum Axis
        {
            XY,
            XZ,
        }
    }
}
