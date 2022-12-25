using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbb1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            var action="";
            while (action != "0")
            {
                Console.WriteLine("Вас вітає Банк№1");
                Console.WriteLine("Що бажаєте зробити:");
                Console.WriteLine("1 - Створити рахунок");
                Console.WriteLine("2 - Зайди до особистого рахунку");
                Console.WriteLine("0 - Вихід");
                action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        string ln, fn, mn, id;
                        Console.WriteLine("Введіть призвіще:");
                        ln = Console.ReadLine();
                        Console.WriteLine("Введіть ім'я:");
                        fn = Console.ReadLine();
                        Console.WriteLine("Введіть ім'я по-батькові:");
                        mn = Console.ReadLine();
                        Console.WriteLine("Введіть id майбутнього рахунку, 8 символів:");
                        id = Console.ReadLine();
                        if (ln != string.Empty && fn != string.Empty && mn != string.Empty && int.TryParse(id, out _))
                        {
                            if (accounts.Count > 0)
                            {
                                for (int i = 0; i < accounts.Count; i++)
                                {
                                    if (accounts[i].ID != id)
                                    {
                                        accounts.Add(new BankAccount(ln, fn, mn, id));
                                        Console.WriteLine("Рахунок створено");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Рахунок з даним ID вже зареєстрований");
                                    }
                                }
                            }
                            else
                            {
                                accounts.Add(new BankAccount(ln, fn, mn, id));
                                Console.WriteLine("Рахунок створено");
                            }    
                        }
                        else
                            action = "1";
                        break;
                    case "2":
                        string ID;
                        Console.WriteLine("Введіть ID рахунку:");
                        ID = Console.ReadLine();

                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (accounts[i].ID == ID)
                            {
                                string action2 = "";
                                while (action2 != "0")
                                {
                                    Console.WriteLine("Вітаємо Вас");
                                    Console.WriteLine(accounts[i].ToString());
                                    Console.WriteLine("Що бажаєте зробити:");
                                    Console.WriteLine("1 - Відкрити депозит");
                                    Console.WriteLine("2 - Поповнити рахунок");
                                    Console.WriteLine("3 - Зняти готівку");
                                    Console.WriteLine("4 - Закрити депозит");
                                    Console.WriteLine("5 - Загальна кількість коштів на депозитах");
                                    Console.WriteLine("0 - Вихід");
                                    action2 = Console.ReadLine();
                                    switch(action2)
                                    {
                                        case "1":
                                            Console.WriteLine("Оберіть депозит");
                                            Console.WriteLine("Depos1");
                                            Console.WriteLine("Depos2");
                                            Console.WriteLine("Depos3");
                                            var a = Console.ReadLine();
                                            Console.WriteLine("Введіть сумму депозиту:");
                                            var b = Console.ReadLine();
                                            if (a != string.Empty && double.Parse(b) > 0)
                                            {
                                                accounts[i].AddDepos(a, double.Parse(b));
                                            }
                                            break;
                                        case "2":
                                            Console.WriteLine("Введіть суму поповнення:");
                                            var mon = Console.ReadLine();
                                            if (double.TryParse(mon, out double m))
                                            {
                                                accounts[i].TopUp(m);
                                            }
                                            else
                                                Console.WriteLine("Помилка");
                                            break;
                                        case "3":
                                            Console.WriteLine("Введіть суму зняття:");
                                            var Mon = Console.ReadLine();
                                            if (double.TryParse(Mon, out m))
                                            {
                                                accounts[i].Windraw(m);
                                            }
                                            break;
                                        case "4":
                                            foreach (var D in accounts[i].mass)
                                                Console.WriteLine(D.Value);
                                            Console.WriteLine("Оберіть депозит для закрыття");
                                            var d = Console.ReadLine();
                                            accounts[i].CloseDep(d);
                                            break;
                                        case "5":
                                            accounts[i].AllMoney();
                                            break;
                                    }

                                }


                            }
                            else
                                Console.WriteLine("Такого рахунку не існує");

                        }

                        break;
                }
            }

           

        }
    }
}
