using UnityEngine;

namespace gtools.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public void SetOffSet(Vector3 pos) => _offSet = pos;
        private Vector3 _offSet;
        
        [SerializeField] private bool followTarget;

        public void SetTarget(Transform targetTransform) => target = targetTransform;
        [SerializeField] private Transform target;
        
        [SerializeField] private float speed;

        private void Start()
        {
            _offSet = target.position - transform.position;
        }

        private void Update()
        {
            if (followTarget && target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position - _offSet, speed);
            }
        }
    }
}
