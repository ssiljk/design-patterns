using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonFactory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private static int count = 0;

        public Person CreatePerson(string name)
        {
            var person = new Person();
            person.Name = name;
            person.Id = count++;
            return person;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pf = new PersonFactory();
            var person1 = pf.CreatePerson("David");
            var person2 = pf.CreatePerson("Raul");
            Console.ReadKey();
        }
    }
}
