using Garage.Objects.Scripts;

namespace Garage.Services
{
    public class CharacterService
    {
        private readonly IAtomicObject _character;

        public CharacterService(IAtomicObject character)
        {
            _character = character;
        }

        public IAtomicObject GetCharacter()
        {
            return _character;
        }
    }
}