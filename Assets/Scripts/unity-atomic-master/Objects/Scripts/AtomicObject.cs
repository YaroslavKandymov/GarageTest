using System.Collections.Generic;
using Garage.Objects.Scripts.Internal;
using UnityEngine;
using UnityEngine.Profiling;

namespace Garage.Objects.Scripts
{
    public abstract class AtomicObject : AtomicObjectBase
    {
        /// <summary>
        ///     <para>Constructor for atomic object</para>
        /// </summary>
        public virtual void Compose()
        {
#if UNITY_EDITOR
            Profiler.BeginSample("AtomicObjectCompose", this);
#endif
            AtomicObjectInfo objectInfo = AtomicCompiler.CompileObject(GetType());
            
            AddTypes(objectInfo.types);
            AddReferences(this, objectInfo.references);
            AddSections(this, objectInfo.sections);
            
#if UNITY_EDITOR
            Profiler.EndSample();
#endif
        }

        private void AddReferences(object source, IEnumerable<ReferenceInfo> definitions)
        {
            foreach (ReferenceInfo definition in definitions)
            {
                string id = definition.id;
                object value = definition.value(source);
                
                if (definition.@override)
                {
                    references[id] = value;
                    continue;
                }

                references.TryAdd(id, value);
            }
        }
        
        private void AddSections(object parent, IEnumerable<SectionInfo> definitions)
        {
            foreach (var definition in definitions)
            {
                object section = definition.GetValue(parent);
                
                AddTypes(definition.types);
                AddReferences(section, definition.references);
                AddSections(section, definition.children);
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu(nameof(Compose))]
        public void ComposeEditor()
        {
            types.Clear();
            references.Clear();
            
            Compose();
        }
#endif
    }
}