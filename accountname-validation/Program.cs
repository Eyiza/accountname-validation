// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result1 = Syarpa("MichealAyodeji_Ogundero", "Micheal, Ogundero Ayodeji");
            Console.WriteLine(result1);
            bool result2 = Syarpa("Micheal Ayodeji~Ogundero", "Micheal-Ogundero_Ayodeji");
            Console.WriteLine(result2);
            bool result3 = Syarpa("MichealAyodeji_Ogundero", "Micheal Ogundero");
            Console.WriteLine(result3);
            bool result4 = Syarpa("Micheal AyodejiOgundero", "Micheal~Ogundero Ayodeji");
            Console.WriteLine(result4);
            bool result5 = Syarpa("Micheal Ayodeji-Ogundero", "Micheal, OgunderoAyodeji");
            Console.WriteLine(result5);
            bool result6 = Syarpa("MichealAyodejiOgundero", "Micheal Ogundero");
            Console.WriteLine(result6);

        }
        public static bool Syarpa(string syarpa_name, string bank_name)
        {

            string[] bank_name_array = Regex.Split(bank_name, @" |,|-|_|~|(?<!^)(?=[A-Z])").Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] syarpa_name_array = Regex.Split(syarpa_name, @" |,|-|_|~|(?<!^)(?=[A-Z])").Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < bank_name_array.Length; i++)
            {
                bank_name_array[i] = bank_name_array[i].ToLower();
            }
            for (int i = 0; i < syarpa_name_array.Length; i++)
            {
                syarpa_name_array[i] = syarpa_name_array[i].ToLower();
            }

            if (bank_name_array.Length == 2)
            {
                int counter = 0;
                foreach (string name in bank_name_array)
                {
                    if (syarpa_name_array.Contains(name))
                    {
                        counter ++;
                    }
                }
                if (counter >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (bank_name_array.Length == 3)
            {
                int counter = 0;
                foreach (string name in syarpa_name_array)
                {
                    if (bank_name_array.Contains(name))
                    {
                        counter ++;
                    }
                }
                if (counter >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
    }
}
