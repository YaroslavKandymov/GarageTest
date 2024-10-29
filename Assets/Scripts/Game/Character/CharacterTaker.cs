using Garage.Behaviours.Scripts;
using Garage.Elements.Scripts.Interfaces;
using Garage.Services;
using Garage.StringFields;
using Garage.UserInput;

namespace Garage.Game.Character
{
    public class CharacterTaker: IEnable, IDisable
    {
        private readonly KeyboardInput _keyboardInput;
        private readonly CharacterService _characterService;
        
        private IAtomicEvent _takeAction;

        public CharacterTaker(KeyboardInput keyboardInput, CharacterService characterService)
        {
            _keyboardInput = keyboardInput;
            _characterService = characterService;
        }

        void IEnable.Enable()
        {
            _takeAction = _characterService.GetCharacter().Get<IAtomicEvent>(ObjectAPI.TakeMechanic);

            _keyboardInput.TakeKeyPressed += OnTakeKeyPressed;
        }

        void IDisable.Disable()
        {
            _keyboardInput.TakeKeyPressed -= OnTakeKeyPressed;
        }

        private void OnTakeKeyPressed(bool value)
        {
            if (value)
            {
                _takeAction?.Invoke();
            }
        }
    }
 
}