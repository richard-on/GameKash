using System;
using System.Collections.Generic;
using System.Text;

namespace GameKash {
    public interface IMagic
    {
        //This interface includes only MagicCasts' without `double power` parameter as it is unused in most implementations
        //IPower.cs shall be used if `double power` is required.
        void MagicCast(Wizard wizard, Character character);
        void MagicCast(Wizard wizard);
    }
}
