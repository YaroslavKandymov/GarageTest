using DG.Tweening;
using Garage.Behaviours.Scripts;
using Garage.StaticData;

namespace Garage.Game.Garage
{
    public class GarageOpener : IEnable
    {
        private readonly GarageData _garageData;
        private readonly GaragePrefab _garagePrefab;

        public GarageOpener(GarageData garageData, GaragePrefab garagePrefab)
        {
            _garageData = garageData;
            _garagePrefab = garagePrefab;
        }

        void IEnable.Enable()
        {
            Open();
        }

        private void Open()
        {
            _garagePrefab.Door.transform
                .DOLocalMove(_garagePrefab.Door.transform.localPosition + _garageData.DoorOffset, _garageData.MoveTime)
                .SetEase(_garageData.Ease);
        }
    }
}