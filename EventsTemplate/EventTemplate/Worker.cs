using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTemplate
{
    //public delegate int WorkPerformedHandler(int hours);
    public class Worker
    {
        public event EventHandler<WorkedPerformedEventArgs> WorkPerformed;//event definition

        public event EventHandler WorkCompleted;

        public void DoWork(int hours)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i);
            }
            OnWorkComplete();

        }

        public void ProcessAction(int x, int y, Action<int, int>action )
        {
            action(x, y);
            Console.WriteLine("Action been processed");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del.Invoke(x, y);
            Console.WriteLine(result);
        }
        
        protected virtual void OnWorkPerformed(int hours)
        {
            var del = WorkPerformed as EventHandler<WorkedPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkedPerformedEventArgs(hours));
            }
        }
        protected virtual void OnWorkComplete()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del.Invoke(this, EventArgs.Empty);
                //del(this, EventArgs.Empty);
            }
        }
    }
}
