using Bogus;
using ilvo_automatisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilvo_automatisation
{
    public class GenerateMockData
    {
        static void GenerateData()
        {
            var namen = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            var test = new Faker<TblStal>()
            //.StrictMode(true)
            .RuleFor(o => o.Id, f => Guid.NewGuid())
           .RuleFor(o => o.Naam, f => f.PickRandom(namen))
           .RuleFor(o => o.Omschrijving, f => f.PickRandom(namen))
           .RuleFor(o => o.FractieVloeibaar, f => f.Random.Number(1, 100))
           .RuleFor(o => o.ReductiePercentage, f => f.Random.Number(1, 100))
           .RuleFor(o => o.MestTypeId, f => Guid.NewGuid())
           .RuleFor(o => o.StalTypeId, f => Guid.NewGuid())
           .RuleFor(o => o.VersieId, f => Guid.NewGuid());
            var stal = test.Generate();
            Console.WriteLine(stal.Id);
            Console.WriteLine(stal.Naam);
            Console.WriteLine(stal.Omschrijving);
            Console.WriteLine(stal.FractieVloeibaar);
            Console.WriteLine(stal.ReductiePercentage);
            Console.WriteLine(stal.MestTypeId);
            Console.WriteLine(stal.StalTypeId);
            Console.WriteLine(stal.VersieId);
        }
    }
}
