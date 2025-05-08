#nullable enable
using System;

namespace NonAllocFlag
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class NonAllocFlagGeneratorAttribute : Attribute
    {
    }
}