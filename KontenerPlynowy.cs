using System;

namespace apbd1
{

    public class KontenerPlynowy : Kontener, IHazardNotifier
    {
        public KontenerPlynowy(double wagaWlasna, double maksLadownosc, double wysokosc, double glebokosc)
            : base(wagaWlasna, maksLadownosc, wysokosc, glebokosc, "L")
        {
        }
        
        public override void Zaladuj(double masa)
        {
            Zaladuj(masa, false);
        }
        
        public void Zaladuj(double masa, bool czyNiebezpieczny)
        {
            double limit = czyNiebezpieczny ? 0.5 * MaksymalnaLadownosc : 0.9 * MaksymalnaLadownosc;
            if (masa > limit)
            {
                WyslijNotyfikacje(NumerSeryjny,
                    $"Próba załadowania {masa} kg, przekraczająca limit {(czyNiebezpieczny ? "dla ładunku niebezpiecznego" : "dla ładunku zwykłego")}: {limit} kg.");
                throw new OverfillException("Przekroczono dozwolony limit ładunku w kontenerze płynowym.");
            }
            if (masa > MaksymalnaLadownosc)
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
            MasaLadunku = masa;
        }
        
        public override void Oproznij()
        {
            MasaLadunku = 0;
        }
        
        public void WyslijNotyfikacje(string numerKontenera, string wiadomosc)
        {
            Console.WriteLine($"[NOTYFIKACJA] Kontener {numerKontenera}: {wiadomosc}");
        }
        
        public override string WypiszInformacje()
        {
            return "Kontener płynowy - " + base.WypiszInformacje();
        }
    }
}