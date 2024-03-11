﻿﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Feladat
            List<Books> books_list = new List<Books>();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }

            Console.WriteLine("4.Feladat");
            foreach (var item in books_list)
            {
                Console.WriteLine($"{item.sorszam} {item.kategoria} {item.konyv} {item.ar} {item.db}");
            }
            Console.WriteLine("5.Feladat");
            //2.Feladat
            int osszdb = 0;
            foreach (var item in books_list)
            {

                osszdb += item.db;


            }
            Console.WriteLine($"Az össz darabszám: {osszdb} db");

            Console.WriteLine("6.Feladat");
            foreach (var book in books_list)
            {
                if (book.kategoria.Equals("Regény"))
                {

                    Console.WriteLine($"A regény kategóriában lévő könyv címe és ára: {book.kategoria},  {book.konyv}, {book.ar} ");
                }
            }

            Console.WriteLine("7.Feladat");
            Dictionary<string, int> kategoriak = new Dictionary<string, int>();

            foreach (var item in books_list)
            {
                if (kategoriak.ContainsKey(item.kategoria))
                {
                    kategoriak[item.kategoria]++;
                }
                else
                {
                    kategoriak[item.kategoria] = 1;
                }
            }

            Console.WriteLine("\nKategóriák és termékek száma:");
            foreach (var kvp in kategoriak)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} termék");
            }



            Console.WriteLine("8.Feladat");
            List<Books> legolcsobbak = new List<Books>(); // Listát használunk az összes legolcsóbb termék tárolásához
            Books legolcsobb = books_list[0];
            legolcsobbak.Add(legolcsobb); // Az első terméket hozzáadjuk a listához

            foreach (var termek in books_list)
            {
                if (termek.ar < legolcsobb.ar)
                {
                    // Ha a jelenlegi termék ára kisebb, akkor ő lesz az egyik legolcsóbb
                    legolcsobb = termek;
                    legolcsobbak.Clear(); // Töröljük a korábbi legolcsóbbakat, mert van újabb
                    legolcsobbak.Add(legolcsobb);
                }
                else if (termek.ar == legolcsobb.ar)
                {
                    // Ha a jelenlegi termék ára megegyezik a legolcsóbb árával, akkor hozzáadjuk a listához
                    legolcsobbak.Add(termek);
                }
            }

            Console.WriteLine("\nLegolcsóbb termek(ek) adatai:");
            foreach (var legolcsobbTermek in legolcsobbak)
            {
                Console.WriteLine($"Kategória: {legolcsobbTermek.kategoria}, {legolcsobbTermek.konyv}, Ár: {legolcsobbTermek.ar}");
            }


            Console.ReadKey();
        }
    }
}
