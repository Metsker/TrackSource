using UnityEngine;

namespace _Scripts.Environment
{
    public class PosZFollower : MonoBehaviour
    {
        [SerializeField] private GameObject objToFollow;

        private float _zOffset;

        private void Start()
        {
            _zOffset = transform.position.z;
        }

        private void Update()
        {
            var t = transform;
            var p = t.position;
            var newZPos = objToFollow.transform.position.z + _zOffset;
        
            var newPos = new Vector3(p.x, p.y, newZPos);
            p = newPos;
            t.position = p;
        }
    }
}
