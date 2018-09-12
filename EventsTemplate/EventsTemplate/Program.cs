using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTemplate
{
    class Program
    {      
        static void Main(string[] args)
        {
            ServiceClass _sClass = new ServiceClass();

            _sClass.myEvent += _sClass_myEventHandler;
            _sClass.SecretFunction(3);
            Console.Read();

        }

        private static void _sClass_myEventHandler(int a)
        {
            Console.WriteLine(a);
        }

    }
}
