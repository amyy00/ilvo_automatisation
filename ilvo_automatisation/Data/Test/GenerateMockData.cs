using Bogus;
using ilvo_automatisation.Models;

namespace ilvo_automatisation.Data.Test;

public class GenerateMockData
{
    public static void GenerateData()
    {
        var names = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };
        Console.WriteLine("generating Mock data ....");
        var tblStalData = new Faker<TblStal>()
            .RuleFor(o => o.Id, f => Guid.NewGuid())
            .RuleFor(o => o.Naam, f => f.PickRandom(names))
            .RuleFor(o => o.Omschrijving, f => f.PickRandom(names))
            .RuleFor(o => o.FractieVloeibaar, f => f.Random.Number(1, 100))
            .RuleFor(o => o.ReductiePercentage, f => f.Random.Number(1, 100))
            .RuleFor(o => o.MestTypeId, f => Guid.NewGuid())
            .RuleFor(o => o.StalTypeId, f => Guid.NewGuid())
            .RuleFor(o => o.VersieId, f => Guid.NewGuid());

        var tblPasData = new Faker<tblPAS>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Naam, f => f.PickRandom(names))
            .RuleFor(p => p.ReductiePercentage, f => f.Random.Double(0, 100))
            .RuleFor(p => p.Passtal, f => f.Random.Bool())
            .RuleFor(p => p.Pasvoeding, f => f.Random.Bool())
            .RuleFor(p => p.Pasweide, f => f.Random.Bool())
            .RuleFor(p => p.VersieId, f => f.Random.Guid())
            .RuleFor(p => p.Versie, f => new TblVersie());

        var tblVersieData = new Faker<TblVersie>()
            .RuleFor(v => v.Id, f => f.Random.Guid())
            .RuleFor(v => v.Naam, f => f.PickRandom(names))
            .RuleFor(v => v.GebruikerId, f => f.Random.Guid())
            .RuleFor(v => v.Publiek, f => f.Random.Bool());

        var lnkGewassenData = new Faker<LnkGewassen>()
            .RuleFor(g => g.Id, f => f.Random.Guid())
            .RuleFor(g => g.CodeHoofdTeelt, f => f.Random.Int(1, 100))
            .RuleFor(g => g.GewasGroepId, f => f.Random.Guid())
            .RuleFor(g => g.VersieId, f => f.Random.Guid())
            .RuleFor(g => g.OmsHoofdTeelt, f => f.PickRandom(names))
            .RuleFor(g => g.GewasGroepOogstrestId, f => f.Random.Guid())
            .RuleFor(g => g.Versie, f => new TblVersie());

        using (var context = new EmavContext())
        {
            for (int i = 0; i < 10000; i++)
            {
                var stal = tblStalData.Generate();
                context.TblStal.Add(stal);
                var pas = tblPasData.Generate();
                context.TblPas.Add(pas);
                var versie = tblVersieData.Generate();
                context.TblVersie.Add(versie);
                var gewassenData = lnkGewassenData.Generate();
                context.LnkGewassen.Add(gewassenData);

            }
            Console.WriteLine("Data is being saved to the database.");
            context.SaveChanges();   
            Console.WriteLine("Generated mock data completed.");
        }
            
    }
}