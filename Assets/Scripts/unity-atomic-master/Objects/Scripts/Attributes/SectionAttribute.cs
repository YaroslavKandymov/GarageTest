using System;
using JetBrains.Annotations;

namespace Garage.Objects.Scripts.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class SectionAttribute : Attribute
    {
    }
}