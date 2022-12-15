using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Set3
{
	class Program
	{
		private static Random rnd = new Random();
        private static List<string> instructions = new List<string>()
        {
            "Lista setul 3",
            "Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.",
            "Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1.",
            "Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz).",
            "Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea.",
            "Se da un vector cu n elemente, o valoare e si o pozitie din vector k. Se cere sa se insereze valoarea e in vector pe pozitia k. Primul element al vectorului se considera pe pozitia zero.",
            "Se da un vector cu n elemente si o pozitie din vector k. Se cere sa se stearga din vector elementul de pe pozitia k. Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga.",
            "Reverse. Se da un vector nu n elemente. Se cere sa se inverseze ordinea elementelor din vector. Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.",
            "Rotire. Se da un vector cu n elemente. Rotiti elementele vectorului cu o pozitie spre stanga. Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc.",
            "Rotire k. Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga.",
            "Cautare binara. Se da un vector cu n elemente sortat in ordine crescatoare. Se cere sa se determine pozitia unui element dat k. Daca elementul nu se gaseste in vector rezultatul va fi -1.",
            "Se da un numar natural n. Se cere sa se afiseze toate numerele prime mai mici sau egale cu n (ciurul lui Eratostene).",
            "Sortare selectie. Implementati algoritmul de sortare <Selection Sort>.",
            "Sortare prin insertie. Implementati algoritmul de sortare <Insertion Sort>.",
            "Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului).",
            "Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector.",
            "Se da un vector de n numere naturale. Determinati cel mai mare divizor comun al elementelor vectorului.",
            "Se da un numar n in baza 10 si un numar b. 1 < b < 17. Sa se converteasca si sa se afiseze numarul n in baza b.",
            "Se da un polinom de grad n ai carui coeficienti sunt stocati intr-un vector. Cel mai putin semnificativ coeficient este pe pozitia zero in vector. Se cere valoarea polinomului intr-un punct x.",
            "Se da un vector s (vectorul in care se cauta) si un vector p (vectorul care se cauta). Determinati de cate ori apare p in s. De ex. Daca s = [1,2,1,2,1,3,1,2,1] si p = [1,2,1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar).",
            "Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2. Determinati numarul de suprapuneri (margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare. Siragurile de margele se pot roti atunci cand le suprapunem.",
            "Se dau doi vectori. Se cere sa se determine ordinea lor lexicografica (care ar trebui sa apara primul in dictionar).",
            "Se dau doi vectori v1 si v2. Se cere sa determine intersectia, reuniunea, si diferentele v1-v2 si v2 -v1 (implementarea operatiilor cu multimi). Elementele care se repeta vor fi scrise o singura data in rezultat.",
            "Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare.",
            "Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare (v[i] este 1 daca i face parte din multime si este 0 in caz contrar).",
            "(Interclasare) Se dau doi vector sortati crescator v1 si v2. Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2. Sunt permise elemente duplicate.",
            "Se dau doua numere naturale foarte mari (cifrele unui numar foarte mare sunt stocate intr-un vector - fiecare cifra pe cate o pozitie). Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.",
            "Se da un vector si un index in vectorul respectiv. Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat.",
            "Quicksort. Sortati un vector folosind metoda QuickSort.",
            "MergeSort. Sortati un vector folosind metoda MergeSort.",
            "Sortare bicriteriala. Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i]. Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima.",
            "(Element majoritate). Intr-un vector cu n elemente, un element m este element majoritate daca mai mult de n/2 din valorile vectorului sunt egale cu m (prin urmare, daca un vector are element majoritate acesta este unui singur).  Sa se determine elementul majoritate al unui vector (daca nu exista atunci se va afisa <nu exista>). (incercati sa gasiti o solutie liniara)."
        };

        private static void Main(string[] args)
        {
            int pbNumber = 0;
            foreach (string instruction in instructions)
            {
                if (pbNumber > 0)
                    Console.Write($"{pbNumber}: ");
                Console.WriteLine(instruction);
                pbNumber++;
            }
            Console.WriteLine();

            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Scrieti numarul problemei (sau \"stop\" pentru oprire): ");
                string array = Console.ReadLine();
                if ( array.CompareTo("stop") == 0)
                    stop= true;
                else
                {
                    try
                    {
                        Solve(Convert.ToInt32(array));
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
              
                }
            }
        }
        /// <summary>
        /// solve the n-th exercise 
        /// </summary>
        /// <param name="n"></param
        private static void Solve(int n)
        {
            switch (n)
            {

                case 1: P1(); break;
              /*  case 2: P2(); break;
                case 3: P3(); break;
                case 4: P4(); break;
                case 5: P5(); break;
                case 6: P6(); break;
                case 7: P7(); break;
                case 8: P8(); break;
                case 9: P9(); break;
                case 10: P10(); break;
                case 11: P11(); break;
                case 12: P12(); break;
                case 13: P13(); break;
                case 14: P14(); break;
                case 15: P15(); break;
                case 16: P16(); break;
                case 17: P17(); break;
                case 18: P18(); break;
                case 19: P19(); break;
                case 20: P20(); break;
                case 21: P21(); break;
                case 22: P22(); break;
                case 23: P23(); break;
                case 24: P24(); break;
                case 25: P25(); break;
                case 26: P26(); break;
                case 27: P27(); break;
                case 28: P28(); break;
                case 29: P29(); break;
                case 30: P30(); break;
                case 31: P31(); break;*/
                default: Console.WriteLine($"Problema cu numarul {n} nu exista :("); break;

            }
            
        }
        /// <summary>
        /// reads N and N integers, then returns an int type array
        /// </summary>
        /// <returns></returns>
        private static int[] ReadArray()
        {
            //basic reading
            Console.Write("Dati n, dupa care dati cele n numere pe linia urmatoare: ");
            int n = Convert.ToInt32(Console.ReadLine());

            char[] separators = { ' ', ',', ':', ';' };
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] intsLine = Array.ConvertAll(line, int.Parse);
            return intsLine;
        }
        /// <summary>
        /// overloaded function which customize the console text for a given string variable name
        /// </summary>
        /// <returns></returns>
        private static int[] ReadArray(string name)
        {
            //basic reading
            Console.Write($"Dati {name}, dupa care dati cele {name} numere pe linia urmatoare: ");
            int n = Convert.ToInt32(Console.ReadLine());

            char[] separators = { ' ', ',', ':', ';' };
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] intsLine = Array.ConvertAll(line, int.Parse);
            return intsLine;
        }
        /// <summary>
        /// Calculati suma elementelor unui vector de n numere citite de la tastatura.Rezultatul se va afisa pe ecran.
        /// </summary>
        private static void P1()
        {
            Console.WriteLine(instructions[1]);
            var array = ReadArray();
            Console.WriteLine($"Suma numerelor din vector este {array.Sum()}");
        }
    }
}