using System;

namespace apbd1
{

    public abstract class Kontener
    {
        public double MasaLadunku { get; protected set; }
        public double Wysokosc { get; protected set; }
        public double WagaWlasna { get; protected set; }
        public double Glebokosc { get; protected set; }
        public string NumerSeryjny { get; protected set; }
        public double MaksymalnaLadownosc { get; protected set; }
        private static int globalCounter = 1;

        public Kontener(double wagaWlasna, double maksLadownosc, double wysokosc, double glebokosc, string typ)
        {
            WagaWlasna = wagaWlasna;
            MaksymalnaLadownosc = maksLadownosc;
            Wysokosc = wysokosc;
            Glebokosc = glebokosc;
            NumerSeryjny = $"KON-{typ}-{globalCounter++}";
            MasaLadunku = 0;
        }

        public abstract void Zaladuj(double masa);

        public abstract void Oproznij();

        public virtual string WypiszInformacje()
        {
            return $"Numer: {NumerSeryjny}, Masa ładunku: {MasaLadunku} kg, Maksymalna ładowność: {MaksymalnaLadownosc} kg";
        }
    }
}