using System.ComponentModel.DataAnnotations;

namespace Cash.BE.Attributes;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class AllowedFilterAttribute: Attribute
{
}