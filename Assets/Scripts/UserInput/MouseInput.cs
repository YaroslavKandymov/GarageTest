using System;
using Cysharp.Threading.Tasks;
using Garage.Behaviours.Scripts;
using Garage.StringFields;
using UnityEngine;

namespace Garage.UserInput
{
    public class MouseInput : IEnable, IDisable
    {
        private bool _isWorking;
        
        public event Action<Vector2> MouseInputChanged;

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
                float mouseX = Input.GetAxis(InputFields.MouseX);
                float mouseY = Input.GetAxis(InputFields.MouseY);
                
                MouseInputChanged?.Invoke(new Vector2(mouseX, mouseY));

                await UniTask.Yield();
            }
        }
    }
}