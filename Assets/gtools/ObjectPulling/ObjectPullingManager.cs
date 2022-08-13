using System.Collections.Generic;
using UnityEngine;

namespace gtools.ObjectPulling
{
    public class ObjectPullingManager : MonoBehaviour
    {
        public static ObjectPullingManager Instance;
        private void Awake() => Instance = this;

        public ObjectPullingInstance prefab;
        public List<ObjectPullingInstance> objectsToSpawn;

        public GameObject SpawnObject(Vector3 position, Quaternion rotation, Transform parent)
        {
            if(objectsToSpawn.Count > 0)
            {
                var go = objectsToSpawn[^1].gameObject;
                objectsToSpawn[^1].Spawn(this, position, rotation, parent);
                objectsToSpawn.RemoveAt(objectsToSpawn.Count - 1);
                return go;
            }
            else
            {
                var go = Instantiate(prefab, parent);
                go.Spawn(this, position, rotation, parent);
                return go.gameObject;
            }
        }
    }
}
