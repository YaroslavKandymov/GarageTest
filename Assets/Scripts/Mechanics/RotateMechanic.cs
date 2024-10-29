using Garage.Elements.Scripts.Interfaces;
using UnityEngine;

namespace Garage.Mechanics
{
    public class RotateMechanic
    {
        private readonly Transform _transform;
        private readonly IAtomicVariable<Vector2> _rotation;
        private readonly IAtomicVariable<float> _speed;
        private readonly IAtomicValue<Vector2> _borders;

        private float _horizontalRotation;
        private float _verticalRotation;

        public RotateMechanic(Transform transform,
            IAtomicVariable<Vector2> rotation, 
            IAtomicVariable<float> speed,
            IAtomicValue<Vector2> borders)
        {
            _transform = transform;
            _rotation = rotation;
            _speed = speed;
            _borders = borders;
        }

        public void Rotate()
        {
            _horizontalRotation -= _rotation.Value.y * _speed.Value;
            _horizontalRotation = Mathf.Clamp(_horizontalRotation, _borders.Value.x, _borders.Value.y);

            float delta = _rotation.Value.x * _speed.Value;
            _verticalRotation = _transform.localEulerAngles.y + delta;

            _transform.localEulerAngles = new Vector3(_horizontalRotation, _verticalRotation, 0);
        }
    }
}