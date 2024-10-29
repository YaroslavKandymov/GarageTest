using Garage.Elements.Scripts.Interfaces;
using Garage.Game.Character;
using UnityEngine;

namespace Garage.Mechanics
{
    public class MoveMechanic
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly IAtomicValue<float> _speed;
        private readonly IAtomicVariable<Vector3> _direction;
        private readonly SurfaceSlider _surfaceSlider;

        public MoveMechanic(Transform transform,
            Rigidbody rigidbody,
            IAtomicValue<float> speed,
            IAtomicVariable<Vector3> direction)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _speed = speed;
            _direction = direction;
            _surfaceSlider = new SurfaceSlider();
        }

        public void Move()
        {
            Vector3 forward = _transform.forward;
            Vector3 right = _transform.right;

            Vector3 directionAlongSurface = _surfaceSlider.Project(_direction.Value.normalized);
            Vector3 offset = (forward * directionAlongSurface.z + right * directionAlongSurface.x) *
                             (_speed.Value * Time.deltaTime);

            var nextPosition = _rigidbody.position + offset;

            _rigidbody.MovePosition(nextPosition);
        }
    }
}