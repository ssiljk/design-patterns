using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder
{   
    public class Field
    {
        public string Nombre, Tipo;
        public Field()
        {

        }

        public Field(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }

    }
    public class Clase
    {
        
        public string Nombre;
        public List<Field> Fields;

        public Clase()
        {
        }

        
    }

    public class CodeBuilder
    {
        private const int identSize = 2;
        Clase clase = new Clase();

        public CodeBuilder(string nombre)
        {
            clase.Nombre = nombre;
            clase.Fields = new List<Field>();
        }

        public CodeBuilder AddField(string nombre, string tipo)
        {
            var field = new Field(nombre, tipo);
            clase.Fields.Add(field);
            return this;            
        }

        private string ToStringImpl(int ident)
        {
            var sb = new StringBuilder();
            var i = new string(' ', identSize * ident);
            sb.Append($"public class {clase.Nombre}\n");
            sb.Append($"{{\n");
            foreach (var field in clase.Fields)
            {
                sb.Append(new string(' ', identSize * (ident + 1)));
                sb.Append($"public {field.Tipo} {field.Nombre};\n");
            }
            sb.Append($"}}\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
            Console.ReadKey();
        }
    }
}
