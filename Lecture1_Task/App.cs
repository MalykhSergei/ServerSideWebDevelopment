using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture1_Task
{
    class App
    {
        private static void Main()
        {
            var person = new Person("Kevin", 45);

            Console.WriteLine(person.Name);
        }
    }
}
