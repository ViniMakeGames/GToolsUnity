using UnityEngine;

namespace gtools.ObjectPulling.Demo
{
    public class DemoSpawner : MonoBehaviour
    {
        [SerializeField] [Range(0f, 100f)] private float spawnRate;
        private float _timer;
        private void Update()
        {
            if (_timer < 1f)
            {
                _timer += spawnRate * Time.deltaTime;
            }
            else
            {
                _timer = 0;
                ObjectPullingManager.Instance.SpawnObject(transform.position + new Vector3(Random.Range(-0.01f, 0.1f), 0, Random.Range(-0.1f, 0.1f)), transform.rotation, transform);
            }
        }
    }
}
