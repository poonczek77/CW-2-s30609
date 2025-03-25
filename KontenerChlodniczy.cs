using System;
using System.Collections.Generic;

namespace apbd1
{

    public class KontenerChlodniczy : Kontener
    {
        public string RodzajProduktu { get; private set; }
        public double TemperaturaUtrzymywana { get; private set; }


        private static readonly Dictionary<string, double> minimalneTemperatury = new Dictionary<string, double>
        {
            {"Banany", 13.3},
            {"Czekolada", 18},
            {"Ryby", 2},
            {"Mieso", -15},
            {"Lody", -18},
            {"Pizza mrozona", -30},
            {"Ser", 7.2},
            {"Parowki", 5},
            {"Maslo", 20.5},
            {"Jaja", 19}
        };

        public KontenerChlodniczy(double wagaWlasna, double maksLadownosc, double wysokosc, double glebokosc, string produkt, double temperatura)
            : base(wagaWlasna, maksLadownosc, wysokosc, glebokosc, "C")
        {
            if (!minimalneTemperatury.ContainsKey(produkt))
                throw new ArgumentException("Nieznany rodzaj produktu.");
            
            double minTemp = minimalneTemperatury[produkt];
            if (temperatura < minTemp)
                throw new Exception($"Temperatura kontenera ({temperatura}°C) jest zbyt niska dla produktu {produkt} (wymagane co najmniej {minTemp}°C).");

            RodzajProduktu = produkt;
            TemperaturaUtrzymywana = temperatura;
        }
        
        public override void Zaladuj(double masa)
        {
            if (masa > MaksymalnaLadownosc)
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera chłodniczego.");
            MasaLadunku = masa;
        }
        
        public override void Oproznij()
        {
            MasaLadunku = 0;
        }
        
        public override string WypiszInformacje()
        {
            return "Kontener chłodniczy - " + base.WypiszInformacje() +
                   $", Produkt: {RodzajProduktu}, Temperatura: {TemperaturaUtrzymywana}°C";
        }
    }
}
