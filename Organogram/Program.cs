using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organogram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\companies_data.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //fit csv records into List of Person types
                    csv.Configuration.HasHeaderRecord = false;
                    var records = csv.GetRecords<Person>().ToList();

                    //order list by Id
                    var orderedList = records.OrderBy(p => p.Id).ToList();
                    var root = orderedList.First();

                    //find and set children of each record in the list
                    foreach (var person in orderedList)
                    {
                        var children = orderedList.Where(p => p.ParentId == person.Id).ToList();
                        if (children.Any())
                        {
                            person.Children = children;
                        }
                    }

                    //print Organogram
                    root.PrintStructure("", true);

                    //print all records sorted by Row Id
                    Console.WriteLine();
                    foreach (var person in orderedList)
                    {
                        Console.WriteLine($"{person.Id} - {person.FirstName} {person.LastName}, {person.Company}, {person.Position}, {person.City}");
                    }

                    Console.ReadKey();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
