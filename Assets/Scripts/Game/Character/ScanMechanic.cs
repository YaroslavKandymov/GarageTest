using Garage.Elements.Scripts.Interfaces;
using Garage.Interfaces;
using UnityEngine;

namespace Garage.Game.Character
{
    public class ScanMechanic
    {
        private readonly IAtomicValue<bool> _condition;
        private readonly Transform _origin;
        private readonly IAtomicValue<float> _distance;
        private readonly IAtomicValue<LayerMask> _layerMask;
        private readonly IAtomicVariable<ITakeble> _takeble;
        
        private IOutlinable _currentItem;

        private readonly RaycastHit[] _hits = new RaycastHit[1];

        public ScanMechanic(IAtomicValue<bool> condition, 
            Transform origin,
            IAtomicValue<float> distance, 
            IAtomicValue<LayerMask> layerMask, 
            IAtomicVariable<ITakeble> takeble)
        {
            _condition = condition;
            _origin = origin;
            _distance = distance;
            _layerMask = layerMask;
            _takeble = takeble;
        }

        public void Update()
        {
            if (_condition.Value)
                return;

            Scan();
        }

        private void Scan()
        {
            var hit = Physics.RaycastNonAlloc(_origin.position, _origin.forward, _hits, _distance.Value, _layerMask.Value);

            if (hit > 0)
            {
                if (_hits[0].collider.TryGetComponent(out _currentItem) && _hits[0].collider.TryGetComponent(out ITakeble takeble))
                {
                    _currentItem.SetActive(true);

                    _takeble.Value = takeble;
                }
                else
                {
                    _currentItem?.SetActive(false);
                }
            }
            else
            {
                _currentItem?.SetActive(false);
            }
        }
    }
}