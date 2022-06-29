using Microsoft.EntityFrameworkCore;
using projekt_p4_konsola;


var context = new MostyContext();
if (!context.Database.EnsureCreated()) Console.WriteLine("BAZA ISTNIEJE");
else 
{
    Console.WriteLine("BAZA NIE ISTNAIŁA");
    var mostt = new Most();
    var proj = new Projekt();
    proj.NumerProjektu = 1;
    proj.DataProjektu = DateTime.Parse("1999-01-01");
    proj.AutorProjektuImie = "Kris";
    proj.AutorProjektuNazwisko = "Kris";
    proj.Rodzaj = "Powykonawczy";
    mostt.NazwaMostu = "Golden chain";
    mostt.NumerProjektu = proj.NumerProjektu;
    mostt.TypMostu = "Most ciezki";
    mostt.DaneTechniczne = "Ciezki most transportowy";
    context.Projekts.AddAsync(proj);
    context.Mosts.AddAsync(mostt);
    context.SaveChangesAsync();
}

string chois;
string projektant;

while (true)
{

    Console.WriteLine("APLIKACJA MOSTY I KLADKI W MIESCIE");
    Console.WriteLine("");
    Console.WriteLine("1.Wyswietl mosty w miescie");
    Console.WriteLine("2.Wyswietl projektantow");
    Console.WriteLine("3.Podaj projektanta, wyswietla zaprojektowane mosty");
    Console.WriteLine("4.Dodaj most");
    Console.WriteLine("k.Koniec");
    chois = Console.ReadLine();

    switch (chois)
    {
        case "1":
            var dane = context.Mosts.ToList();
            foreach (var item in dane)
            {
                Console.WriteLine($"{item.NazwaMostu}");
            }
            Console.ReadKey();
            break;

        case "2":
            var dane_1 = context.Projekts.ToList();
            foreach (var item in dane_1)
            {
                Console.WriteLine($"{item.AutorProjektuImie}  {item.AutorProjektuNazwisko}");
            }
            Console.ReadKey();
            break;

        case "3":
            Console.WriteLine("Podaj nazwisko");
            projektant = Console.ReadLine();
            var dane_2 = context.Projekts.Include(x=>x.Mosts).Where(x => x.AutorProjektuNazwisko == projektant);
            Console.WriteLine("WYNIK:");

            foreach (var item in dane_2)
            {
                Console.WriteLine($"{item.AutorProjektuImie} {item.AutorProjektuNazwisko} PROJEKTOWANE MOSTY: ");

                foreach (var ite in item.Mosts)
                {
                    Console.WriteLine($"{ite.NazwaMostu}");
                }
            }
            Console.ReadKey();
            break;

        case "4":
            var mostt = new Most();
            var proj = new Projekt();

            Console.WriteLine("Dodawanie mostu");
            Console.WriteLine("Podaj numer projektu");

            try
            {
                proj.NumerProjektu = Int32.Parse(Console.ReadLine());
                var numery = context.Projekts.Select(x=>x.NumerProjektu);
                foreach (var item in numery)
                {
                    if(proj.NumerProjektu==item)
                    {
                        Console.WriteLine("Bledny numer");
                        return;

                    }
                }
            }
            catch
            {
                Console.WriteLine("Blad");
            }

            Console.WriteLine("Podaj date projektu");
            proj.DataProjektu = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Podaj Imie projektanta:");
            proj.AutorProjektuImie = Console.ReadLine();

            Console.WriteLine("Podaj Nazwisko projektanta:");
            proj.AutorProjektuNazwisko = Console.ReadLine();

            Console.WriteLine("Podaj typ projektu:");
            proj.Rodzaj = Console.ReadLine();


            Console.WriteLine("Podaj nazwę mostu");
            mostt.NazwaMostu = Console.ReadLine();
            mostt.NumerProjektu = proj.NumerProjektu;
            Console.WriteLine("Podaj typ mostu");
            mostt.TypMostu = Console.ReadLine();

            Console.WriteLine("Opis techno");
            mostt.DaneTechniczne = Console.ReadLine();


            context.Projekts.AddAsync(proj);
            context.Mosts.AddAsync(mostt);
          
            
            context.SaveChangesAsync();


            break;

        case "k":
            return;

        default:
            Console.WriteLine("Zly wybor");
            Console.ReadKey();
            break;
    }


    System.Console.Clear();
}


