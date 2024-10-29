using System;
using Garage.Elements.Scripts.Interfaces;
using Garage.Interfaces;
using UnityEngine;

namespace Garage.Game.Actions
{
    [Serializable]
    public class TakeAction
    {
        private Transform _parent;
        private IAtomicVariable<bool> _isBusy;
        private IAtomicValue<float> _force;
        private IAtomicEvent _event;
        private IAtomicValue<ITakeble> _takeble;

        public void Compose(Transform parent, 
            IAtomicVariable<bool> isBusy, 
            IAtomicValue<float> force, 
            IAtomicEvent takeEvent,
            IAtomicValue<ITakeble> takeble)
        {
            _parent = parent;
            _isBusy = isBusy;
            _force = force;
            _event = takeEvent;
            _takeble = takeble;
        }

        public void OnEnable()
        {
            _event.Subscribe(OnEvent);
        }
        
        public void OnDisable()
        {
            _event.Unsubscribe(OnEvent);
        }

        private void OnEvent()
        {
            if(_takeble.Value == null)
                return;
            
            Invoke(_takeble.Value);
        }

        public void Invoke(ITakeble takeble)
        {
            if (_isBusy.Value == false)
            {
                _isBusy.Value = true;
                
                takeble.Take(_parent);
            }
            else
            {
                takeble.Release(_force.Value);

                _isBusy.Value = false;
            }
        }
    }
}