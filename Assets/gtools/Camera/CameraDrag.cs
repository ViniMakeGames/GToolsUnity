using System;
using UnityEngine;

namespace gtools.Camera
{
    public class CameraDrag : MonoBehaviour
    {
        [SerializeField] private float dragSpeed;
        [SerializeField] private Mode mode;
        public bool lockX, lockY;

        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
        
            switch (mode)
            {
                case Mode.Move:
                    transform.Translate(lockX ? 0 : dragSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, lockY ? 0 : dragSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, 0, Space.World);
                    break;
                case Mode.Rotate:
                    transform.Rotate(lockY ? 0 : dragSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, lockX ? 0 : dragSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, 0, Space.World);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum Mode
        {
            Move,
            Rotate,
        }
    }
}
