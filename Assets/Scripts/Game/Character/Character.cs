using System;
using Garage.Game.Components;
using Garage.Objects.Scripts;
using Garage.Objects.Scripts.Attributes;

namespace Garage.Game.Character
{
    public class Character : AtomicObject
    {
        [Section] public MoveComponent MoveComponent;
        [Section] public RotateComponent RotateComponent;
        [Section] public TakeComponent TakeComponent;

        private void Awake()
        {
            base.Compose();

            MoveComponent.Compose(transform);
            RotateComponent.Compose(transform);
            TakeComponent.Compose();
        }

        private void OnEnable()
        {
            TakeComponent.OnEnable();
        }

        private void OnDisable()
        {
            TakeComponent.OnDisable();
        }

        private void Update()
        {
            MoveComponent.Update();
            RotateComponent.Update();
            TakeComponent.Update();
        }
    }
}