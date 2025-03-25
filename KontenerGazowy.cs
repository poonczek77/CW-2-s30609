using System;

namespace apbd1
{

    public class KontenerGazowy : Kontener, IHazardNotifier
    {
        public double Cisnienie { get; private set; }

        public KontenerGazowy(double wagaWlasna, double maksLadownosc, double wysokosc, double glebokosc, double cisnienie)
            : base(wagaWlasna, maksLadownosc, wysokosc, glebokosc, "G")
        {
            Cisnienie = cisnienie;
        }

        public override void Zaladuj(double masa)
        {
            if (masa > MaksymalnaLadownosc)
            {
                WyslijNotyfikacje(NumerSeryjny,
                    $"Próba załadowania {masa} kg, przekraczająca maksymalną ładowność {MaksymalnaLadownosc} kg.");
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera gazowego.");
            }
            MasaLadunku = masa;
        }

        public override void Oproznij()
        {
            MasaLadunku *= 0.05;
        }

        public void WyslijNotyfikacje(string numerKontenera, string wiadomosc)
        {
            Console.WriteLine($"[NOTYFIKACJA] Kontener {numerKontenera}: {wiadomosc}");
        }

        public override string WypiszInformacje()
        {
            return "Kontener gazowy - " + base.WypiszInformacje() + $", Ciśnienie: {Cisnienie} atm";
        }
    }
}