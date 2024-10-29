using System;
using System.Collections.Generic;
using Garage.Objects.Scripts;
using UnityEngine;

namespace Garage.Behaviours.Scripts
{
    public class AtomicBehaviour : AtomicObject
    {
        private HashSet<ILogic> logicSet;
        
        private Dictionary<string, ILogic> logicMap;

        private List<IEnable> enables;
        private List<IDisable> disables;
        private List<IUpdate> updates;
        private List<IFixedUpdate> fixedUpdates;
        private List<ILateUpdate> lateUpdates;

        private void Awake()
        {
            Compose();
        }

        public override void Compose()
        {
            base.Compose();
            logicSet = new HashSet<ILogic>();
            logicMap = new Dictionary<string, ILogic>();

            enables = new List<IEnable>();
            disables = new List<IDisable>();

            updates = new List<IUpdate>();
            fixedUpdates = new List<IFixedUpdate>();
            lateUpdates = new List<ILateUpdate>();
        }

        public bool AddLogic(string key, ILogic target)
        {
            if (logicMap.TryAdd(key, target))
            {
                return AddLogic(target);
            }

            return false;
        }

        public bool AddLogic(ILogic target)
        {
            if (target == null)
            {
                return false;
            }

            if (!logicSet.Add(target))
            {
                return false;
            }

            if (target is IEnable enable)
            {
                enables.Add(enable);

                if (enabled)
                {
                    enable.Enable();
                }
            }

            if (target is IDisable disable)
            {
                disables.Add(disable);
            }

            if (target is IUpdate update)
            {
                updates.Add(update);
            }

            if (target is IFixedUpdate fixedUpdate)
            {
                fixedUpdates.Add(fixedUpdate);
            }

            if (target is ILateUpdate lateUpdate)
            {
                lateUpdates.Add(lateUpdate);
            }

            return true;
        }
        
        public bool RemoveLogic(string key)
        {
            if (logicMap.Remove(key, out var target))
            {
                return RemoveLogic(target);
            }

            return false;
        }

        public bool RemoveLogic(ILogic target)
        {
            if (target == null)
            {
                return false;
            }
            
            if (!logicSet.Remove(target))
            {
                return false;
            }

            if (target is IEnable enable)
            {
                enables.Remove(enable);
            }

            if (target is IUpdate tickable)
            {
                updates.Remove(tickable);
            }

            if (target is IFixedUpdate fixedTickable)
            {
                fixedUpdates.Remove(fixedTickable);
            }

            if (target is ILateUpdate lateTickable)
            {
                lateUpdates.Remove(lateTickable);
            }

            if (target is IDisable disable)
            {
                if (enabled)
                {
                    disable.Disable();
                }
            }

            return true;
        }

        public void AddLogics(IEnumerable<ILogic> targets)
        {
            foreach (var target in targets)
            {
                AddLogic(target);
            }
        }

        public void RemoveLogics(IEnumerable<ILogic> targets)
        {
            foreach (var target in targets)
            {
                RemoveLogic(target);
            }
        }

        public bool FindLogic<T>(out T result) where T : ILogic
        {
            foreach (var element in logicSet)
            {
                if (element is T tElement)
                {
                    result = tElement;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public bool RemoveLogic<T>() where T : ILogic
        {
            foreach (var element in logicSet)
            {
                if (element is T)
                {
                    RemoveLogic(element);
                    return true;
                }
            }

            return false;
        }

        protected virtual void OnEnable()
        {
            for (int i = 0, count = enables.Count; i < count; i++)
            {
                IEnable enable = enables[i];
                enable.Enable();
            }
        }

        protected virtual void OnDisable()
        {
            for (int i = 0, count = disables.Count; i < count; i++)
            {
                IDisable disable = disables[i];
                disable.Disable();
            }
        }

        protected virtual void Update()
        {
            float deltaTime = Time.deltaTime;
            
            for (int i = 0, count = updates.Count; i < count; i++)
            {
                IUpdate update = updates[i];
                update.OnUpdate(deltaTime);
            }
        }

        protected virtual void FixedUpdate()
        {
            float deltaTime = Time.fixedDeltaTime;
            
            for (int i = 0, count = fixedUpdates.Count; i < count; i++)
            {
                IFixedUpdate fixedUpdate = fixedUpdates[i];
                fixedUpdate.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;

            for (int i = 0, count = lateUpdates.Count; i < count; i++)
            {
                ILateUpdate lateUpdate = lateUpdates[i];
                lateUpdate.OnLateUpdate(deltaTime);
            }
        }
    }
}