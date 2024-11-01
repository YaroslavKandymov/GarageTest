using System;
using System.Collections.Generic;
using Garage.Elements.Scripts.Interfaces;

namespace Garage.Elements.Scripts.Implementations
{
    [Serializable]
    public abstract class AtomicExpression<T> : IAtomicExpression<T>
    {
        private readonly List<IAtomicValue<T>> members = new();

        public void Append(IAtomicValue<T> member)
        {
            this.members.Add(member);
        }

        public void Remove(IAtomicValue<T> member)
        {
            this.members.Remove(member);
        }
        
        public T Invoke()
        {
            return this.Invoke(this.members);
        }

        protected abstract T Invoke(IReadOnlyList<IAtomicValue<T>> members);
    }
    
    public abstract class AtomicExpression<T, R> : IAtomicExpression<T, R>
    {
        private readonly List<IAtomicFunction<T, R>> members = new();

        public void Append(IAtomicFunction<T, R> member)
        {
            this.members.Add(member);
        }

        public void Remove(IAtomicFunction<T, R> member)
        {
            this.members.Remove(member);
        }
       
        public R Invoke(T args)
        {
            return this.Invoke(this.members, args);
        }

        protected abstract R Invoke(IReadOnlyList<IAtomicFunction<T, R>> members, T args);
    }
}