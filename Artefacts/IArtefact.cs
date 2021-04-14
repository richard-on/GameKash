namespace GameKash.Artefacts
{
    public interface IArtefact
    {
        void ArtefactCast(Wizard wizard, Character character);
        void ArtefactCast(Wizard wizard);
    }
}