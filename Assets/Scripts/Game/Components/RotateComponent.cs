using System;
using Garage.Elements.Scripts.Implementations;
using Garage.Mechanics;
using Garage.Objects.Scripts.Attributes;
using Garage.StringFields;
using UnityEngine;

namespace Garage.Game.Components
{
    [Serializable]
    public class RotateComponent
    {
        [Get(ObjectAPI.RotateMechanic)]
        [SerializeField] private AtomicVariable<Vector2> _rotation;
        [SerializeField] private AtomicVariable<float> _rotateSpeed;
        [SerializeField] private AtomicValue<Vector2> _borders;
        
        private RotateMechanic _rotateMechanic;

        public void Compose(Transform transform)
        {
            _rotateMechanic = new RotateMechanic(transform, _rotation, _rotateSpeed, _borders);
        }

        public void Update()
        {
            _rotateMechanic.Rotate();
        }
    }
}