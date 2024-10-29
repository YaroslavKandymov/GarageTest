using System;
using Garage.Elements.Scripts.Implementations;
using Garage.Elements.Scripts.Interfaces;
using Garage.Game.Actions;
using Garage.Game.Character;
using Garage.Interfaces;
using Garage.Objects.Scripts.Attributes;
using Garage.StringFields;
using UnityEngine;

namespace Garage.Game.Components
{
    [Serializable]
    public class TakeComponent
    {
        [Get(ObjectAPI.TakeMechanic)]
        [SerializeField] private AtomicEvent _clickAction;
        [SerializeField] private Transform _parent;
        [SerializeField] private TakeAction _takeAction;
        [SerializeField] private AtomicValue<Transform> _origin;
        [SerializeField] private AtomicValue<float> _force;
        [SerializeField] private AtomicVariable<bool> _isBusy;
        [SerializeField] private AtomicValue<float> _distance;
        [SerializeField] private AtomicValue<LayerMask> _layerMask;
        
        private IAtomicVariable<ITakeble> _takeble;
        private ScanMechanic _scanMechanic;
        
        public void Compose()
        {
            _takeble = new AtomicVariable<ITakeble>();
            
            _takeAction.Compose(_parent, _isBusy, _force, _clickAction, _takeble);
            _scanMechanic = new ScanMechanic(_isBusy, _origin.Value, _distance, _layerMask, _takeble);
        }

        public void OnEnable()
        {
            _takeAction.OnEnable();
        }
        
        public void OnDisable()
        {
            _takeAction.OnDisable();
        }

        public void Update()
        {
            _scanMechanic.Update();
        }
    }
}