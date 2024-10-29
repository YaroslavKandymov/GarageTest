using System;
using Garage.Elements.Scripts.Interfaces;

namespace Garage.Elements.Scripts.Implementations
{
    [Serializable]
    public sealed class AtomicFunction<T> : IAtomicFunction<T>
    {
        private Func<T> func;
        
        public T Value
        {
            get { return this.func != null ? this.func.Invoke() : default; }
        }

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T> func)
        {
            this.func = func;
        }

        public void Compose(Func<T> func)
        {
            this.func = func;
        }

        public T Invoke()
        {
            return this.func != null ? this.func.Invoke() : default;
        }
    }

    [Serializable]
    public sealed class AtomicFunction<T, R> : IAtomicFunction<T, R>
    {
        private Func<T, R> func;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T, R> func)
        {
            this.func = func;
        }

        public void Compose(Func<T, R> func)
        {
            this.func = func;
        }

        public R Invoke(T args)
        {
            return this.func.Invoke(args);
        }
    }
}