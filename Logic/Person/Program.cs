using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            Person person = new Person("Béla", "balba", "0630");
            //person.Serialize();
            Person.Deserialize(1);
            Console.ReadKey();
            //}
        }
    }
}
