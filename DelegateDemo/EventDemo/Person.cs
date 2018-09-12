using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Person
    {
        public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
        private string name;

        public Person()
        {
            name = "initial";
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;//assignment of args
                    args.NewName = value;
                    NameChanged(this, args);
                }
                name = value;
            }
        }

        public event NameChangedDelegate NameChanged;
    }
}
