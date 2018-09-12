using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTemplate
{

    public class ServiceClass
    {
        public delegate void MyHandler(int a);
        public event MyHandler myEvent;
        public void SecretFunction(int a)
        {
            Console.WriteLine("Fired Event");
            myEvent(a);
        }
    }
}
