using System;

namespace Auth.Domain.Enum
{
    [Flags]
    public enum PermisionValue : uint
    {
        Deny = 0,
        Allow = 1
    }


}
