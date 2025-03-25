using System;
using System.Collections.Generic;
using System.Linq;

namespace apbd1
{
    public class Kontenerowiec
    {
        public List<Kontener> Kontenery { get; private set; }
        public double MaksymalnaPredkosc { get; private set; }
        public int MaksymalnaLiczbaKontenerow { get; private set; }
        public double MaksymalnaWaga { get; private set; }

        public Kontenerowiec(double maksPredkosc, int maksLiczba, double maksWaga)
        {
            MaksymalnaPredkosc = maksPredkosc;
            MaksymalnaLiczbaKontenerow = maksLiczba;
            MaksymalnaWaga = maksWaga;
            Kontenery = new List<Kontener>();
        }
        
        public void DodajKontener(Kontener kontener)
        {
            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
            {
                Console.WriteLine("Nie można dodać kontenera: przekroczono limit kontenerów.");
                return;
            }
            
            double sumaWag = Kontenery.Sum(k => k.WagaWlasna + k.MasaLadunku)
                               + kontener.WagaWlasna + kontener.MasaLadunku;
            if (sumaWag > MaksymalnaWaga * 1000)
            {
                Console.WriteLine("Nie można dodać kontenera: przekroczono limit wagowy.");
                return;
            }
            Kontenery.Add(kontener);
            Console.WriteLine($"Dodano kontener {kontener.NumerSeryjny} do kontenerowca.");
        }
        
        public void DodajListeKontenerow(List<Kontener> listaKontenerow)
        {
            foreach (var kontener in listaKontenerow)
            {
                DodajKontener(kontener);
            }
        }

        public void UsunKontener(string numerSeryjny)
        {
            var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                Kontenery.Remove(kontener);
                Console.WriteLine($"Usunięto kontener {numerSeryjny} z kontenerowca.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera o podanym numerze.");
            }
        }

        public void RozladowanieKontenera(string numerSeryjny)
        {
            var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                kontener.Oproznij();
                Console.WriteLine($"Rozładowano kontener {numerSeryjny}.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera o podanym numerze.");
            }
        }

        public void ZamienKontener(string numerSeryjny, Kontener nowyKontener)
        {
            int index = Kontenery.FindIndex(k => k.NumerSeryjny == numerSeryjny);
            if (index != -1)
            {
                Kontenery[index] = nowyKontener;
                Console.WriteLine($"Zamieniono kontener {numerSeryjny} na {nowyKontener.NumerSeryjny}.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera do zamiany.");
            }
        }

        public void PrzeniesKontener(Kontenerowiec innyStatek, string numerSeryjny)
        {
            var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                innyStatek.DodajKontener(kontener);
                Kontenery.Remove(kontener);
                Console.WriteLine($"Przeniesiono kontener {numerSeryjny} do innego kontenerowca.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera do przeniesienia.");
            }
        }

        public void WypiszInformacje()
        {
            Console.WriteLine("Informacje o kontenerowcu:");
            Console.WriteLine($"Maksymalna prędkość: {MaksymalnaPredkosc} węzłów");
            Console.WriteLine($"Maksymalna liczba kontenerów: {MaksymalnaLiczbaKontenerow}");
            Console.WriteLine($"Maksymalna waga ładunku: {MaksymalnaWaga} ton");
            Console.WriteLine("Lista kontenerów:");
            foreach (var kontener in Kontenery)
            {
                Console.WriteLine(kontener.WypiszInformacje());
            }
            Console.WriteLine();
        }
    }
}
