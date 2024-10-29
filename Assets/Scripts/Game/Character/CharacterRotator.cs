using Garage.Behaviours.Scripts;
using Garage.Elements.Scripts.Interfaces;
using Garage.Services;
using Garage.StringFields;
using Garage.UserInput;
using UnityEngine;

namespace Garage.Game.Character
{
    public class CharacterRotator : IEnable, IDisable
    {
        private readonly MouseInput _mouseInput;
        private readonly CharacterService _characterService;
        
        private IAtomicVariable<Vector2> _rotateMechanic;

        public CharacterRotator(MouseInput mouseInput, CharacterService characterService)
        {
            _mouseInput = mouseInput;
            _characterService = characterService;
        }

        void IEnable.Enable()
        {
            _rotateMechanic = _characterService.GetCharacter().Get<IAtomicVariable<Vector2>>(ObjectAPI.RotateMechanic);

            _mouseInput.MouseInputChanged += OnMouseInputChanged;
        }

        void IDisable.Disable()
        {
            _mouseInput.MouseInputChanged -= OnMouseInputChanged;
        }

        private void OnMouseInputChanged(Vector2 direction)
        {
            _rotateMechanic.Value = direction;
        }
    }
}