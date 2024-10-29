using System;
using Garage.Elements.Scripts.Interfaces;

namespace Garage.Elements.Scripts.Implementations
{
    [Serializable]
    public sealed class AtomicProperty<T> : IAtomicVariable<T>
    {
        public T Value
        {
            get { return this.getter.Invoke(); }
            set { this.setter.Invoke(value); }
        }

        private Func<T> getter;
        private Action<T> setter;

        public AtomicProperty()
        {
        }

        public AtomicProperty(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        public void Compose(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }
    }
}