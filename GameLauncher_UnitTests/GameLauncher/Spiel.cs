namespace GameLauncher
{
    internal class Spiel
    {
        private string Titel;
        public string titel
        {
            get { return Titel; }
        }
        private string Genre;
        public string genre
        {
            get { return Genre; }
        }
        private string Publisher;
        public string publisher
        {
            get { return Publisher; }
        }
        private int USK;
        public int usk
        {
            get { return USK; }
        }
        private string InstallationsPfad;
        public string installationsPfad
        {
            get { return InstallationsPfad; }
        }
        private string Executable;
        public string executable
        {
            get { return Executable; }
        }
        public Spiel(string newTitel, string newGenre, string newPublisher, int newUSK, string newInstallationspfad, string newExecutable)
        {
            Titel = newTitel;
            Genre = newGenre;
            Publisher = newPublisher;
            USK = newUSK;
            InstallationsPfad = newInstallationspfad;
            Executable = newExecutable;
        }
    }
}