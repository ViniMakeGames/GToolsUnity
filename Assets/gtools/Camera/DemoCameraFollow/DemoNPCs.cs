using UnityEngine;

namespace gtools.Camera.DemoCameraFollow
{
    public class DemoNPCs : MonoBehaviour
    {
        private int _behaviour = 0;
        private float _behaviourTimer = 0;

        private void Update()
        {
            transform.Translate(0,5 * Time.deltaTime, 0, Space.Self);
            
            switch (_behaviour)
            {
                case 1:
                    transform.Rotate(0,0,100 * Time.deltaTime);
                    break;
                case 2:
                    transform.Rotate(0,0,-100 * Time.deltaTime);
                    break;
            }

            if (_behaviourTimer <= 0)
            {
                _behaviourTimer = Random.Range(1f, 5f);
                _behaviour = Random.Range(0, 3);
            }
            else
            {
                _behaviourTimer -= 1 * Time.deltaTime;
            }

            if (Random.Range(0f, 10000f) < 1f)
            {
                GameObject.Find("Main Camera").GetComponent<CameraFollow>().SetTarget(transform);
            }
        }
    }
}
