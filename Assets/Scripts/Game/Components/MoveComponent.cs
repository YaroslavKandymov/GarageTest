using System;
using Garage.Elements.Scripts.Implementations;
using Garage.Mechanics;
using Garage.Objects.Scripts.Attributes;
using Garage.StringFields;
using UnityEngine;

namespace Garage.Game.Components
{
    [Serializable]
    public class MoveComponent
    {
        [Get(ObjectAPI.MoveMechanic)]
        [SerializeField] private AtomicVariable<Vector3> _moveDirection;
        [SerializeField] private AtomicVariable<float> _moveSpeed;
        [SerializeField] private Rigidbody _rigidbody;

        private MoveMechanic _moveMechanic;

        public void Compose(Transform transform)
        {
            _moveMechanic = new MoveMechanic(transform, _rigidbody, _moveSpeed, _moveDirection);
        }

        public void Update()
        {
            _moveMechanic.Move();
        }
    }
}