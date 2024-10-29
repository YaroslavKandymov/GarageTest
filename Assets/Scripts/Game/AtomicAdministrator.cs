using Garage.Behaviours.Scripts;
using Garage.Game.Character;
using Garage.Game.Garage;
using Garage.UserInput;
using Zenject;

namespace Garage.Game
{
    public class AtomicAdministrator : IInitializable
    {
        private readonly AtomicBehaviour _atomicBehaviour;
        private readonly AxisInput _axisInput;
        private readonly MouseInput _mouseInput;
        private readonly KeyboardInput _keyboardInput;
        private readonly CharacterMover _characterMover;
        private readonly CharacterRotator _characterRotator;
        private readonly CharacterTaker _characterTaker;
        private readonly GarageOpener _garageOpener;

        public AtomicAdministrator(AtomicBehaviour atomicBehaviour,
            AxisInput axisInput, 
            MouseInput mouseInput, 
            KeyboardInput keyboardInput, 
            CharacterMover characterMover,
            CharacterRotator characterRotator,
            CharacterTaker characterTaker,
            GarageOpener garageOpener)
        {
            _atomicBehaviour = atomicBehaviour;
            _axisInput = axisInput;
            _mouseInput = mouseInput;
            _keyboardInput = keyboardInput;
            _characterMover = characterMover;
            _characterRotator = characterRotator;
            _characterTaker = characterTaker;
            _garageOpener = garageOpener;
        }

        void IInitializable.Initialize()
        {
            _atomicBehaviour.AddLogic(_axisInput);
            _atomicBehaviour.AddLogic(_mouseInput);
            _atomicBehaviour.AddLogic(_keyboardInput);
            _atomicBehaviour.AddLogic(_characterMover);
            _atomicBehaviour.AddLogic(_characterRotator);
            _atomicBehaviour.AddLogic(_characterTaker);
            _atomicBehaviour.AddLogic(_garageOpener);
        }
    }
}