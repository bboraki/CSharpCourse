﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(20);
            customerManager.List();

            Product product = new Product {Id = 1, Name = "Laptop"};
            Product product2 = new Product(2,"Computer");

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10;
            Utilities.Validate();

            Manager.DoSomething(); //Static nesneler direkt çektirilebilir.
            Manager manager = new Manager();
            manager.DoSomething2();

            Console.ReadLine();
        }

        class CustomerManager
        {
            private int _Count = 0;
            public CustomerManager(int count)
            {
                _Count = count;
            }

            public void List()
            {
                Console.WriteLine("Listed {0} items", _Count);
            }

            public void Add()
            {
                Console.WriteLine("Added!");
            }
        }

        class Product
        {
            public Product()
            {
                
            }

            private int _id;
            private string _name;
            public Product(int id, string name)
            {
                _id = id;
                _name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }

        interface ILogger
        {
            void Log();
        }

        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Added to database");
            }
        }

        class FileLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Added to file");
            }
        }

        class EmployeeManager
        {
            private ILogger _logger;
            public EmployeeManager(ILogger logger)
            {
                _logger = logger;
            }
            public void Add()
            {
                _logger.Log();
                Console.WriteLine("Added Log!");
            }
        }

        class BaseClass
        {
            private string _entity;
            public BaseClass(string entity)
            {
                _entity = entity;
            }

            public void Message()
            {
                Console.WriteLine("{0} message", _entity);
            }
        }

        class PersonManager : BaseClass //inherit
        {
            public PersonManager(string entity):base(entity)
            {
                
            }

            public void Add()
            {
                Console.WriteLine("Added!");
                Message();
            }
        }

        static class Teacher
        {
            public static int Number { get; set; }
        }

        static class Utilities //static bir sınıfın içindeki her bir nesne static olmak zorundadır.
        {
            static Utilities()
            {
                
            }
            public static void Validate()
            {
                Console.WriteLine("Validation is done");
            }
        }

        class Manager //herhangi bir sınıfın içinde de static kullanılabilir.
        {
            public static void DoSomething()
            {
                Console.WriteLine("Done");
            }

            public void DoSomething2()
            {
                Console.WriteLine("Done 2");
            }
        }

    }
}
