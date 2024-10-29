using Garage.Behaviours.Scripts;
using Garage.Game;
using Garage.Game.Character;
using Garage.Game.Garage;
using Garage.Objects.Scripts;
using Garage.Services;
using Garage.UserInput;
using UnityEngine;
using Zenject;

namespace Garage.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private AtomicBehaviour _atomicBehaviour;
        [SerializeField] private AtomicObject _character;
        [SerializeField] private GaragePrefab _garagePrefab;
        
        public override void InstallBindings()
        {
            BindAtomicBehavior();
            BindAxisInput();
            BindMouseInput();
            BindKeyboardInput();
            BindCharacter();
            BindCharacterService();
            BindCharacterMover();
            BindCharacterRotator();
            BindCharacterTaker();
            BindGaragePrefab();
            BindGarageOpener();
            BindAtomicAdministrator();
        }

        private void BindAtomicBehavior()
        {
            Container
                .Bind<AtomicBehaviour>()
                .FromInstance(_atomicBehaviour)
                .AsSingle()
                .NonLazy();
        }

        private void BindAxisInput()
        {
            Container
                .Bind<AxisInput>()
                .AsSingle();
        }
        
        private void BindMouseInput()
        {
            Container
                .Bind<MouseInput>()
                .AsSingle();
        }
        
        private void BindKeyboardInput()
        {
            Container
                .Bind<KeyboardInput>()
                .AsSingle();
        }

        private void BindCharacter()
        {
            Container
                .Bind<IAtomicObject>()
                .FromInstance(_character)
                .AsSingle();
        }

        private void BindCharacterService()
        {
            Container
                .Bind<CharacterService>()
                .AsSingle();
        }

        private void BindCharacterMover()
        {
            Container
                .Bind<CharacterMover>()
                .AsSingle();
        }
        
        private void BindCharacterRotator()
        {
            Container
                .Bind<CharacterRotator>()
                .AsSingle();
        }
        
        private void BindCharacterTaker()
        {
            Container
                .Bind<CharacterTaker>()
                .AsSingle();
        }
        
        private void BindGaragePrefab()
        {
            Container
                .Bind<GaragePrefab>()
                .FromInstance(_garagePrefab);
        }
        
        private void BindGarageOpener()
        {
            Container
                .Bind<GarageOpener>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAtomicAdministrator()
        {
            Container
                .BindInterfacesAndSelfTo<AtomicAdministrator>()
                .AsSingle()
                .NonLazy();
        }
    }
}
