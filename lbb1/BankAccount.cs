using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbb1
{
    class BankAccount
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string ID;

        public Dictionary<double, string> mass = new Dictionary<double, string>();

        enum Depos
        {

            Depos1 = 14,
            Depos2 = 12,
            Depos3 = 19
        }
        public double Rah = 0;

        public BankAccount(string LastName, string FirstName, string MiddleName, string ID)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.ID = ID;
        }

        public void AddDepos(string NameDep, double money)
        {

            if (NameDep == Depos.Depos1.ToString())
            {
                mass.Add(money, NameDep);
                Console.WriteLine($"Депозит {NameDep} відкрито");
            }
            else if (NameDep == Depos.Depos2.ToString())
            {
                mass.Add(money, NameDep);
                Console.WriteLine($"Депозит {NameDep} відкрито");
            }
            else if (NameDep == Depos.Depos3.ToString())
            {
                mass.Add(money, NameDep);
                Console.WriteLine($"Депозит {NameDep} відкрито");
            }
            else
            {
                Console.WriteLine("Невірна назва депозиту");
            }

        }

        public double Income(string NameDep)
        {
            double m = 0;
            foreach (var dep in mass)
            {
                if (dep.Value == NameDep)
                {
                    if (NameDep == Depos.Depos1.ToString())
                    {
                        
                        m = dep.Key + dep.Key * ((double)Depos.Depos1/100f);
                        return m;

                    }
                    else if (NameDep == Depos.Depos2.ToString())
                    {
                        m = dep.Key+dep.Key * ((double)Depos.Depos2 / 100f);
                        return m;
                    }
                    else if (NameDep == Depos.Depos3.ToString())
                    {
                        m = dep.Key + dep.Key * ((double)Depos.Depos3 / 100f);
                        return m;
                    }

                }
            }
            return m;

        }

        public void TopUp(double money)
        {
            Rah += money;
            Console.WriteLine($"Рахунок поповнено на сумму: {money}");

        }
        public void Windraw(double money)
        {
            if(Rah>money)
            {
                Rah -= money;
                Console.WriteLine($"З рахунку знято грошей на сумму: {money}");
            }
            
        }

        public void CloseDep(string namedep)
        {
            foreach (var dep in mass)
            {
                if (dep.Value == namedep)
                {
                    Rah += Income(namedep);
                    mass.Remove(dep.Key);
                    Console.WriteLine($"Депозит {namedep} закрито");
                    break;
                }
                else
                    Console.WriteLine($"Депозиту {namedep} неіснує");
            }
        }

        public void AllMoney()
        {
            double all=0;
            foreach(var dep in mass)
            {
                all += dep.Key;
            }
            Console.WriteLine($"Грошей на депозитах: {all}");
        }

        public override string ToString()
        {
            return String.Format("Призвіще: {0} , Ім'я: {1}, По-батькові: {2}, Номер рахунку: {3}, Кількість депозитів: {4}, Рахунок:{5}", this.LastName,this.FirstName,this.MiddleName,this.ID,this.mass.Count.ToString(),this.Rah.ToString());
        }



    }
}
