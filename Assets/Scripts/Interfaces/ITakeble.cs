using UnityEngine;

namespace Garage.Interfaces
{
    public interface ITakeble
    {
        public void Take(Transform parent);
        public void Release(float force);
    }
}