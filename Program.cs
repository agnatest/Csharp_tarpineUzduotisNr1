using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarpineUzd1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tarpine uzduotis Nr1 - Agna Semaškaitė

            // kuris keliones budas yra geresnis gamtai ir/ar jusu piniginei
            // 1. suskaiciuoti - kiek co2 kg ismetama keliaujant lektuvu ar automobiliu
            // 2. apskaiciuoti abieju keliones budu kaina
            // 3. visa info, variantu palyginimima ir isvadas isvest i ekrana

            Console.WriteLine("Programa, skirta apskaičiuoti, kuris kelionės būdas yra\n" +
                "geresnis gamtai ir/ar jūsų piniginei.");
            Console.WriteLine("\nĮveskite, ar ką naudojate: dyzeliną ar benziną - D/B? ");
            string kuras = Console.ReadLine();
            Console.WriteLine("\nĮveskite degalų sunaudojimo kiekį (l/100km): ");
            var degaluSunaudojimas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nĮveskite miesto pavadinimą į kurį važiuojate: ");
            string miestas = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\nĮveskite atstumą iki įvardinto miesto į kurį važiuojate (km): ");
            var atstumas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nĮveskite lėktuvo bilieto kainą į šį miestą: ");
            var bilietoKaina = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nĮveskite keleivių skaičių(max 5): ");
            int keleiviuSkaicius = Convert.ToInt32(Console.ReadLine());

            double dyzelinoKaina = 1.126;
            double benzinoKaina = 1.196;
            double dyzelinoCO2IsmetamasKiekis = 2.64;
            double benzinoCO2IsmetamasKiekis = 2.392;
            double lektuvoCO2IsmetamasKiekis = 101;
            double sunaudotasKuras = 0;
            double automobilioKaina = 0;
            double lektuvoKaina = bilietoKaina * keleiviuSkaicius;
            double CO2BendrasIsmetimas = 0;
            double lektuvoCO2BendrasIsmetimas = 0;

            if (keleiviuSkaicius > 0 && keleiviuSkaicius <= 5)
            {

                if (keleiviuSkaicius == 1)
                {
                    lektuvoCO2BendrasIsmetimas = (lektuvoCO2IsmetamasKiekis / 1000) * atstumas; // gramus pavercia i kg
                    Console.WriteLine("\nLėktuvo bilietas vienam keleiviui kainuoja {0} Eur," +
                        "\nSkrendant lėktuvu i '{1}' buvo bendrai išmesta {2} kg CO2 teršalų. ", bilietoKaina, miestas, Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2));
                }
                else
                {
                    lektuvoCO2BendrasIsmetimas = (lektuvoCO2IsmetamasKiekis / 1000) * atstumas; // gramus pavercia i kg
                    Console.WriteLine("\nLėktuvo bilietas vienam keleiviui kainuoja {0} Eur," +
                        " o {1} keleiviams - {2} Eur. \nSkrendant lėktuvu buvo bendrai išmesta {3} kg CO2 teršalų. ",
                        bilietoKaina, keleiviuSkaicius, Math.Round(lektuvoKaina, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2));
                }
                if (kuras.ToLower() == "d")
                {
                    sunaudotasKuras = (atstumas / 100) * degaluSunaudojimas; // kuro sunaudojimo skaiciavimas
                    automobilioKaina = sunaudotasKuras * dyzelinoKaina;
                    CO2BendrasIsmetimas = dyzelinoCO2IsmetamasKiekis * sunaudotasKuras;

                    Console.WriteLine("\nKelionėje '{0}' sunaudotas kuras, kai buvo važiuojama " +
                        "dyzelino kuru - {1} l. \nDyzelino kaina yra {2} Eur/l, todėl bendra kelionės kaina " +
                        "automobiliu yra {3} Eur. \nTaip pat šioje kelionėje buvo išmesta {4}" +
                        " kg CO2 teršalų.", miestas, sunaudotasKuras, dyzelinoKaina, Math.Round(automobilioKaina, 2), Math.Round(CO2BendrasIsmetimas, 2));

                    if (CO2BendrasIsmetimas > (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' lėktuvu yra žymiai geresnė gamtai ({1} kg mašina > {2} kg lėktuvu) " +
                            "\nir jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas > (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' lėktuvu yra žymiai geresnė gamtai ({1} kg mašina > {2} kg lėktuvu), " +
                            "\n BET ne jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas < (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina yra žymiai geresnė gamtai ({1} kg mašina < {2} kg lėktuvu), " +
                            "\n BET ne jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas < (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina yra žymiai geresnė gamtai ({1} kg mašina < {2} kg lėktuvu), " +
                            "\n ir jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai yra vienodai lygios ({1} kg mašina = {2} kg lėktuvu)," +
                            "\n bet lėktuvu yra pigiau jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai yra vienodai lygios ({1} kg mašina = {2} kg lėktuvu)," +
                            "\n bet mašina yra pigiau jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina == lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai ({1} kg mašina = {2} kg lėktuvu) " +
                            "\n ir jūsų piniginei ({3} Eur mašina = {4} Eur lėktuvu) yra vienodai lygios.", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }

                }
                else if (kuras.ToLower() == "b")
                {
                    sunaudotasKuras = (atstumas / 100) * degaluSunaudojimas; // kuro sunaudojimo skaiciavimas
                    automobilioKaina = sunaudotasKuras * benzinoKaina;
                    CO2BendrasIsmetimas = benzinoCO2IsmetamasKiekis * sunaudotasKuras;

                    Console.WriteLine("\nKelionėje '{0}' sunaudotas kuras, kai buvo važiuojama " +
                        "benzino kuru - {1} l. \nBenzino kaina yra {2} Eur/l, todėl bendra kelionės kaina " +
                        "automobiliu yra {3} Eur. \nTaip pat šioje kelionėje buvo išmesta {4}" +
                        " kg CO2 teršalų.", miestas, sunaudotasKuras, benzinoKaina, Math.Round(automobilioKaina, 2), Math.Round(CO2BendrasIsmetimas, 2));

                    if (CO2BendrasIsmetimas > (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' lėktuvu yra žymiai geresnė gamtai ({1} kg mašina > {2} kg lėktuvu) " +
                            "\nir jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas > (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' lėktuvu yra žymiai geresnė gamtai ({1} kg mašina > {2} kg lėktuvu), " +
                            "\n BET ne jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas < (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina yra žymiai geresnė gamtai ({1} kg mašina < {2} kg lėktuvu), " +
                            "\n BET ne jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas < (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina yra žymiai geresnė gamtai ({1} kg mašina < {2} kg lėktuvu), " +
                            "\n ir jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).",
                            miestas, Math.Round(CO2BendrasIsmetimas, 2), Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina < lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai yra vienodai lygios ({1} kg mašina = {2} kg lėktuvu)," +
                            "\n bet lėktuvu yra pigiau jūsų piniginei ({3} Eur mašina < {4} Eur lėktuvu).", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina > lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai yra vienodai lygios ({1} kg mašina = {2} kg lėktuvu)," +
                            "\n bet mašina yra pigiau jūsų piniginei ({3} Eur mašina > {4} Eur lėktuvu).", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                    else if (CO2BendrasIsmetimas == (lektuvoCO2BendrasIsmetimas * keleiviuSkaicius) && automobilioKaina == lektuvoKaina)
                    {
                        Console.WriteLine("\nIŠVADA: Taigi, ši kelionė '{0}' mašina ar lėktuvu gamtai ({1} kg mašina = {2} kg lėktuvu) " +
                            "\n ir jūsų piniginei ({3} Eur mašina = {4} Eur lėktuvu) yra vienodai lygios.", miestas, Math.Round(CO2BendrasIsmetimas, 2),
                            Math.Round(lektuvoCO2BendrasIsmetimas * keleiviuSkaicius, 2), Math.Round(automobilioKaina, 2), lektuvoKaina);
                    }
                }
                else
                {
                    Console.WriteLine("\nBlogai įvedėte naudojamo kuro pasirinkimą.");
                }
            }
            else
            {
                Console.WriteLine("\nKeleivių skaičius negali būti neigiamas arba viršyti 5.");
            }
            Console.ReadLine();
        }

    }
}
