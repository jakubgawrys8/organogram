using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organogram
{
    public class Person
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int ThirdNumber { get; set; }
        public List<Person> Children = new List<Person>();

        public void PrintStructure(string indent, bool first)
        {
            Console.Write(indent);
            if (!first)
            {
                Console.Write(" -> ");
                indent += "  ";
            }

            Console.WriteLine($"{FirstName} {LastName}, {Company}, {Position}");

            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].PrintStructure(indent, false);
            }

        }

    }
}
