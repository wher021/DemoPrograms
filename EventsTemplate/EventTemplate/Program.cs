using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventTemplate
{
    public delegate void myHandler(int number);
    class Program
    {
        static void Main(string[] args)
        {
            //myHandler handler = new myHandler(myFunction);
            //handler(2);
            Worker myWorker = new Worker();
            myWorker.WorkPerformed += MyWorker_WorkPerformed;//new EventHandler<WorkedPerformedEventArgs>(MyWorker_WorkPerformed);
            myWorker.WorkCompleted += (s, e) => Console.WriteLine("done");
            myWorker.DoWork(10);

            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            myWorker.ProcessAction(2,3, myAction);

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            myWorker.ProcessFunc(3,2,funcAddDel);

            Console.Read();
        }

        private static void MyWorker_WorkPerformed(object sender, WorkedPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours);
        }

        public static void myFunction(int number)
        {
            Console.WriteLine(number);
        }
    }
}
