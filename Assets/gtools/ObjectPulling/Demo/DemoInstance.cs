using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gtools.ObjectPulling.Demo
{
    public class DemoInstance : ObjectPullingInstance
    {
        private float _aliveTime = 0;

        private void OnEnable()
        {
            _aliveTime = 0;
            
            GetComponent<MeshRenderer>().material.color =
                new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }

        private void Update()
        {
            _aliveTime += 1 * Time.deltaTime;
            
            if (!(_aliveTime >= 8)) return;
            
            gameObject.SetActive(false);
        }
    }
}
