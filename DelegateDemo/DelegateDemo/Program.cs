using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person myPerson = new Person();
            myPerson.NameChanged += new NameChangedDelegate(OnNameChanged);
            myPerson.NameChanged += new NameChangedDelegate(OnNameChanged2);
            myPerson.Name = "hello";
            myPerson.Name = "will";
            Console.Read();

        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine("Person name changed from {0} to {1}",existingName,newName);
        }
        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }
    }
}
