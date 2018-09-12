using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person();
            a.NameChanged += OnNameChanged;
            a.Name = "wa";
            a.Name = "bb";
            Console.Read();
        }

        static public void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("{0}, {1}", args.ExistingName,args.NewName);
        }
    }
}
