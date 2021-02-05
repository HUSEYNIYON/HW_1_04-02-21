using System;

namespace HW_1_04_02_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectDB DbControler = new ConnectDB();
            while (true)
            {
                Console.Write("\n\tВыберите комманду:\n1.Добавить\n2.Удалить\n3.Выбрать всё\n4.Выбрать один по Id\n5.Обновить\n6.Выход\n\n");
                Console.Write("Ваш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.Write("LastName: ");
                            string LastName = Console.ReadLine();
                            Console.Write("FirstName: ");
                            string FirstName = Console.ReadLine();
                            Console.Write("MiddleName: ");
                            string MiddleName = Console.ReadLine();
                            Console.Write("BirthDate(2020-04-15): ");
                            string BirthDate = Console.ReadLine();
                            DbControler.Insert(FirstName, LastName, MiddleName, BirthDate);
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Id: ");
                            int Id = int.Parse(Console.ReadLine());
                            DbControler.Delete(Id);
                        }
                        break;
                    case "3":
                        {
                            DbControler.SelectAll();
                        }
                        break;
                    case "4":
                        {
                            Console.Write("Id: ");
                            int Id = int.Parse(Console.ReadLine());
                            DbControler.SelectById(Id);
                        }
                        break;
                    case "5":
                        {
                            Console.Write("LastName: ");
                            string LastName = Console.ReadLine();
                            Console.Write("FirstName: ");
                            string FirstName = Console.ReadLine();
                            Console.Write("MiddleName: ");
                            string MiddleName = Console.ReadLine();
                            Console.Write("BirthDate(2020-04-15): ");
                            string BirthDate = Console.ReadLine();
                            Console.Write("Id: ");
                            int Id = int.Parse(Console.ReadLine());
                            DbControler.UpdateById(Id, FirstName, LastName, MiddleName, BirthDate);
                        }
                        break;
                    case "6": { return; }
                }
            }
        }
    }
}
