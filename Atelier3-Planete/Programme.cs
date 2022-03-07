/**
* But: Classe Planete, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 23/02/2022 
**/

using System;

namespace Atelier3_Planete
{
    
    class Programme
    {
        static void Main(string[] args)
        {
            Planete p1 = new Planete("Hellooo", 6371);
            Planete p2 = new Planete("chicago", 994, 9.5);
            Planete p3 = new Planete("bbbb", 6371);
            Planete p4 = new Planete("aaaa", 99, 44444.5);
            Planete p5 = new Planete("Hellooo", 6371);
            Planete p6 = new Planete("azzz", 99, 44444.5);

            p1.Masse = 4.5;

            Console.WriteLine(p1.Nom);
            Console.WriteLine(p1.Rayon);
            Console.WriteLine(p1.Masse);
            Console.WriteLine(p1.Superficie);
            Console.WriteLine(p1.Volume);
            Console.WriteLine(p1.MasseVolumique);
            Console.WriteLine(p1.PlusVolumineuse(p2).Nom);
            Console.WriteLine(p2.PlusDense(p4).Nom);

            Console.ReadLine();
        }
    }
}