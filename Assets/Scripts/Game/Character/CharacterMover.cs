using Garage.Behaviours.Scripts;
using Garage.Elements.Scripts.Interfaces;
using Garage.Services;
using Garage.StringFields;
using Garage.UserInput;
using UnityEngine;

namespace Garage.Game
{
    public class CharacterMover : IEnable, IDisable
    {
        private readonly AxisInput _axisInput;
        private readonly CharacterService _characterService;
        private IAtomicVariable<Vector3> _moveMechanic;

        public CharacterMover(AxisInput axisInput, CharacterService characterService)
        {
            _axisInput = axisInput;
            _characterService = characterService;
        }

        void IEnable.Enable()
        {
            _moveMechanic = _characterService.GetCharacter().Get<IAtomicVariable<Vector3>>(ObjectAPI.MoveMechanic);

            _axisInput.AxisInputChanged += OnAxisInputChanged;
        }

        void IDisable.Disable()
        {
            _axisInput.AxisInputChanged -= OnAxisInputChanged;
        }

        private void OnAxisInputChanged(Vector3 direction)
        {
            _moveMechanic.Value = direction;
        }
    }
}