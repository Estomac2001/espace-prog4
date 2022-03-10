/**
* But: Classe Main, qui teste les différentes classes.
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
            Planete p4 = new Planete("aaaa", 99, 2.5);
            Planete p5 = new Planete("azzz", 6371, 44.5);
            Planete p6 = p1 + p5;
            Planete p7 = p5 - p4;

            Satellite s1 = new Satellite("Hey", 300, 0.2);
            Satellite s2 = new Satellite("Ho", 50, 0.1);
            Satellite s3 = new Satellite("Ha", 1000, 0.5);
            Satellite s4 = s1 + s2;

            p2[0] = s1;

            p2[1] = s4;


            Planete[] planetes = { p1, p2, p3, p4, p6 };

     
            p1.Masse = 4.5;

            Console.WriteLine(p1.Nom);
            Console.WriteLine(p1.Rayon);
            Console.WriteLine(p1.Masse);
            Console.WriteLine(p1.Superficie);
            Console.WriteLine(p1.Volume);
            Console.WriteLine(p1.MasseVolumique);
            Console.WriteLine(p1.PlusVolumineuse(p2).Nom);
            Console.WriteLine(p2.PlusDense(p4).Nom);
            Console.WriteLine(p5.Equals(p3));
            Console.WriteLine(Planete.IndexOf(planetes, p5));
            Console.WriteLine(p6.ToString());
            Console.WriteLine(p4 > p2);
            Console.WriteLine(p6.ToString());
            Console.WriteLine(p7.ToString() + "\n");

            Console.WriteLine(p2[0].ToString() + "\n");
            Console.WriteLine(p2[1].ToString());

            Console.ReadLine();
        }
    }
}