using System;
using Cysharp.Threading.Tasks;
using Garage.Behaviours.Scripts;
using Garage.StaticData;
using UnityEngine;

namespace Garage.UserInput
{
    public class KeyboardInput : IEnable, IDisable
    {
        private readonly KeyCodesData _keyCodesData;
        
        private bool _isWorking;
        
        public event Action<bool> TakeKeyPressed;

        public KeyboardInput(KeyCodesData keyCodesData)
        {
            _keyCodesData = keyCodesData;
        }

        void IEnable.Enable()
        {
            _isWorking = true;

            Update().Forget();
        }

        void IDisable.Disable()
        {
            _isWorking = false;
        }

        private async UniTaskVoid Update()
        {
            while (_isWorking)
            {
                bool takeKey = Input.GetKeyDown(_keyCodesData.TakeItemCode);
                
                TakeKeyPressed?.Invoke(takeKey);

                await UniTask.Yield();
            }
        }
    }
}