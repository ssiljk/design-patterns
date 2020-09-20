using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalBuilder
{
    public class Person
    {
        public string Name, Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }

        public Func<string, string> selector = str => str.ToUpper();

    }
    

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        public readonly List<Func<Person, Person>> actions
          = new List<Func<Person, Person>>();

        public TSelf Do(Action<Person> action) => AddAction(action);

        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));

        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSelf) this;
        }

    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    //public sealed class PersonBuilder
    //{
    //    public readonly List<Func<Person, Person>> actions
    //      = new List<Func<Person, Person>>();

    //    public PersonBuilder Called(string name) => Do(p => { p.Name = name; });

    //    public PersonBuilder Do(Action<Person> action) => AddAction(action);

    //    private PersonBuilder AddAction(Action<Person> action)
    //    {
    //        actions.Add(p => { action(p); return p; });
    //        return this;
    //    }


   //    public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));

    //}

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA
          (this PersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }

    public class FunctionalBuilder
    {
        public static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
            Console.WriteLine(person);
           
            

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };

            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(person.selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);
            Console.ReadKey();
        }
    }
}
