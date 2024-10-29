using System;
using Cysharp.Threading.Tasks;
using Garage.Behaviours.Scripts;
using Garage.StringFields;
using UnityEngine;

namespace Garage.UserInput
{
    public class AxisInput : IEnable, IDisable
    {
        private bool _isWorking;
        
        public event Action<Vector3> AxisInputChanged;

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
                float horizontalDelta = Input.GetAxis(InputFields.Horizontal);
                float verticalDelta = Input.GetAxis(InputFields.Vertical);

                AxisInputChanged?.Invoke(new Vector3(horizontalDelta, 0, verticalDelta));

                await UniTask.Yield();
            }
        }
    }
}