using System;
using JetBrains.Annotations;

namespace Garage.Objects.Scripts.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class GetAttribute : Attribute
    {
        internal readonly string Id;
        internal readonly bool Override;

        public GetAttribute(string Id, bool Override = false)
        {
            this.Id = Id;
            this.Override = Override;
        }
    }
}