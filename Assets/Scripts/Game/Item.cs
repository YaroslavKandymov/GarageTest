using Garage.Interfaces;
using UnityEngine;

namespace Garage.Game
{
    [RequireComponent(typeof(Outline))]
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour, ITakeble, IOutlinable
    { 
        private Outline _outline;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
            _rigidbody = GetComponent<Rigidbody>();
            
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            _outline.enabled = value;
        }

        public void Take(Transform parent)
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(parent);

            transform.localPosition = Vector3.zero;
        }

        public void Release(float force)
        {
            transform.SetParent(null);
            _rigidbody.isKinematic = false;

            _rigidbody.velocity = Vector3.right * force;
        }
    }
}