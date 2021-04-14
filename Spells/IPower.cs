namespace GameKash.Spells
{
    public interface IPower : IMagic
    {
        //This interface includes  MagicCasts' with `double power` parameter and inherits original IMagic interface
        //If `double power` is not required, IMagic.cs shall be used.
        void MagicCast(Wizard wizard, Character character, double power);
        void MagicCast(Wizard wizard, double power);
    }
}