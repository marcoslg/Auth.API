using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain
{
    public sealed class Version
    {
        public uint Major { get; internal set; }
        public uint Minor { get; internal set; }
        public uint Minus { get; internal set; }

        public Version(uint major, uint minor, uint minus)
        {
            Major = major;
            Minor = minor;
            Minus = minus;
        }
    }
}
