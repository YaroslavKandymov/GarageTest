using System;
using Garage.Elements.Scripts.Interfaces;
using Garage.Elements.Scripts.Utils;

namespace Garage.Elements.Scripts.Implementations
{
    [Serializable]
    public class AtomicEvent : IAtomicEvent, IDisposable
    {
        private Action onEvent;

        public void Subscribe(Action action)
        {
            onEvent += action;
        }

        public void Unsubscribe(Action action)
        {
            onEvent -= action;
        }
        
        public virtual void Invoke()
        {
            onEvent?.Invoke();
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref onEvent);
        }
    }

    [Serializable]
    public class AtomicEvent<T> : IAtomicEvent<T>, IDisposable
    {
        private Action<T> onEvent;
        
        public void Subscribe(Action<T> action)
        {
            onEvent += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            onEvent -= action;
        }

        public virtual void Invoke(T direction)
        {
            onEvent?.Invoke(direction);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref onEvent);
        }
    }
    
    [Serializable]
    public class AtomicEvent<T1, T2> : IAtomicEvent<T1, T2>, IDisposable
    {
        private Action<T1, T2> onEvent;
        
        public void Subscribe(Action<T1, T2> action)
        {
            onEvent += action;
        }

        public void Unsubscribe(Action<T1, T2> action)
        {
            onEvent -= action;
        }

        public virtual void Invoke(T1 args1, T2 args2)
        {
            onEvent?.Invoke(args1, args2);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref onEvent);
        }
    }
    
    [Serializable]
    public class AtomicEvent<T1, T2, T3> : IAtomicEvent<T1, T2, T3>, IDisposable
    {
        private Action<T1, T2, T3> onEvent;
        
        public void Subscribe(Action<T1, T2, T3> action)
        {
            onEvent += action;
        }

        public void Unsubscribe(Action<T1, T2, T3> action)
        {
            onEvent -= action;
        }

        public virtual void Invoke(T1 args1, T2 args2, T3 args3)
        {
            onEvent?.Invoke(args1, args2, args3);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref onEvent);
        }
    }
}