using UnityEngine;

namespace gtools.ObjectPulling
{
    public class ObjectPullingInstance : MonoBehaviour
    {
        private ObjectPullingManager _manager;
        public virtual void Spawn(ObjectPullingManager manager, Vector3 position, Quaternion rotation, Transform parent)
        {
            var rigidBody = GetComponent<Rigidbody>();

            if (rigidBody != null)
            {
                rigidBody.velocity = Vector3.zero;
            }
            
            _manager = manager;
            gameObject.SetActive(true);

            var transform1 = transform;
            transform1.position = position;
            transform1.rotation = rotation;

            transform1.parent = parent;
        }

        private void OnDisable()
        {
            _manager.objectsToSpawn.Add(this);
        }
    }
}
