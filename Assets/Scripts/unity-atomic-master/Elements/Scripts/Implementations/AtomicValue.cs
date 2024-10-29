using System;
using Garage.Elements.Scripts.Interfaces;
using UnityEngine;

namespace Garage.Elements.Scripts.Implementations
{
    [Serializable]
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        public T Value
        {
            get { return this.value; }
        }

        [SerializeField]
        private T value;

        public AtomicValue(T value)
        {
            this.value = value;
        }
    }
}