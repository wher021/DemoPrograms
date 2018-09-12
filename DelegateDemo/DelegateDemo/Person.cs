using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void NameChangedDelegate(string existingName, string newName);//signature
    class Person
    {
        private string name;

        public Person()
        {
            name = "www";
        }
        public string Name
        {
            set
            {
                if (name != value)
                {
                    NameChanged(name, value);
                }
                name = value; 
                
            }
            get { return name; }
        }


        public NameChangedDelegate NameChanged;//public member
    }
}
