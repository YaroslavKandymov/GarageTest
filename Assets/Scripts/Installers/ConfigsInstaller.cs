using Garage.StaticData;
using UnityEngine;
using Zenject;

namespace Garage.Installers
{
    [CreateAssetMenu(fileName = "new ConfigsInstaller", menuName = "StaticData/ConfigsInstaller", order = 0)]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GarageData _garageData;
        [SerializeField] private KeyCodesData _keyCodesData;

        public override void InstallBindings()
        {
            BindGarageData();
            BindKeyCodesData();
        }

        private void BindGarageData()
        {
            Container.BindInstance(_garageData).AsSingle();
        }
        
        private void BindKeyCodesData()
        {
            Container.BindInstance(_keyCodesData).AsSingle();
        }
    }
}