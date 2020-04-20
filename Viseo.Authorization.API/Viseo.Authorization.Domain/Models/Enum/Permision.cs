using System;

namespace Viseo.Authorization.Domain.Models.Enum
{
    [Flags]
    public enum Permision : uint
    {
        Deny = 0,
        Allow = 1
    }


}
