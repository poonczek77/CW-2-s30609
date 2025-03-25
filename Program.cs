using System;
using System.Collections.Generic;

namespace apbd1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
             
                var kontenerPlynowy = new KontenerPlynowy(1000, 5000, 250, 300);

                kontenerPlynowy.Zaladuj(4000, false);

                var kontenerGazowy = new KontenerGazowy(1200, 6000, 260, 320, 1.5);

                kontenerGazowy.Zaladuj(5500);

                var kontenerChlodniczy = new KontenerChlodniczy(1500, 7000, 240, 310, "Ryby", 5);

                kontenerChlodniczy.Zaladuj(6000);

                var statek = new Kontenerowiec(10, 100, 40000);


                statek.DodajKontener(kontenerPlynowy);
                statek.DodajKontener(kontenerGazowy);
                statek.DodajKontener(kontenerChlodniczy);

                statek.WypiszInformacje();
                
                statek.RozladowanieKontenera(kontenerGazowy.NumerSeryjny);
                Console.WriteLine("Po rozładowaniu kontenera gazowego:");
                statek.WypiszInformacje();
                
                var nowyKontenerPlynowy = new KontenerPlynowy(1000, 5000, 250, 300);
                nowyKontenerPlynowy.Zaladuj(4500, false);
                statek.ZamienKontener(kontenerPlynowy.NumerSeryjny, nowyKontenerPlynowy);

                Console.WriteLine("Po zamianie kontenera płynowego:");
                statek.WypiszInformacje();

                var statek2 = new Kontenerowiec(12, 80, 35000);
                statek.PrzeniesKontener(statek2, kontenerChlodniczy.NumerSeryjny);

                Console.WriteLine("Stan kontenerowca 1 po przeniesieniu kontenera:");
                statek.WypiszInformacje();
                Console.WriteLine("Stan kontenerowca 2:");
                statek2.WypiszInformacje();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }
}
