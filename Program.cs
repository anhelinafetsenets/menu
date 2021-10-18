using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace menu
{
   
 
  

    class Program
    {
          const string PATH_PRICE = @"C:\Users\admin\source\repos\HW7_2\HW7_2\Price.txt ";
        const string PATH_MENU = @"C:\Users\admin\source\repos\HW7_2\HW7_2\Menu.txt ";

        static void switchCommand(double []last, string[] sub)
        {

                switch (sub[0])
                {
                    case "Potato":
                        {
                            last[0] = Convert.ToDouble(sub[1]);
                            break;
                        }
                    case "Beet":
                        {
                            last[1] = Convert.ToDouble(sub[1]);
                            break;
                        }
                    case "Cherry":
                        {
                            last[4] = Convert.ToDouble(sub[1]);
                            break;
                        }
                    case "Carrot":
                        {
                            last[2] = Convert.ToDouble(sub[1]);
                            break;
                        }
                    case "Egg":
                        {
                            last[3] = Convert.ToDouble(sub[1]);
                            break;
                        }
                }
            
        }

        static public void AddIngridients(KeyValuePair<string, double> a, Dictionary<string, double> menu)
        {
            if (menu.ContainsKey(a.Key))
            {
                menu[a.Key] += a.Value;
            }
            else
            {
                menu.Add(a.Key, a.Value);
            }
        }

        static Dictionary<string,double> Read(string filepath)
        {
            Dictionary<string, double> price = new Dictionary<string, double>();
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    string[] subs = line.Split(" ");
                    price.Add(subs[0], Convert.ToDouble(subs[1]));
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
                
            }
           
            return price;
        }
        static Dictionary<string, double> ReadMenu(string filepath)
        {
            Dictionary<string, double> menu = new Dictionary<string, double>();
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    string[] subs = line.Split(" ");
                    if (subs[1] != null)
                    {
                        KeyValuePair<string,double> a = new KeyValuePair<string, double>(subs[0], Convert.ToDouble(subs[1]));
                        AddIngridients(a, menu);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");

            }
            return menu;
        }

        static void Main(string[] args)
        {

            Dictionary<string, double> priceList = new Dictionary<string, double>();
            Console.WriteLine("Enter path of file with price: ");

            priceList = Read(Console.ReadLine());

            Dictionary<string, double> menuList = new Dictionary<string, double>();
            Console.WriteLine("Enter path of file with menu: ");

            menuList = ReadMenu(Console.ReadLine());

            foreach(KeyValuePair<string, double> a in menuList)
            {
                if (priceList.ContainsKey(a.Key))
                {
                    Console.WriteLine($"{a.Key} {priceList[a.Key] * a.Value} {a.Value}");
                }
            }




        }
    }
    
}
