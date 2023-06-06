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

        var tblPasData = new Faker<TblPas>()
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
            .RuleFor(v => v.Publiek, f => f.Random.Bool())
            .RuleFor(v => v.Gebruiker, f => new TblGebruiker())
            .RuleFor(v => v.LnkGewassens, f => new List<LnkGewassen>())
            .RuleFor(v => v.LnkKunstmestGroepStreeks, f => new List<LnkKunstmestGroepStreek>())
            .RuleFor(v => v.LnkKunstmests, f => new List<LnkKunstmest>())
            .RuleFor(v => v.LnkMestDierPlaats, f => new List<LnkMestDierPlaat>())
            .RuleFor(v => v.LnkMestTechniekPlaats, f => new List<LnkMestTechniekPlaat>())
            .RuleFor(v => v.LnkMestToedieningsEmissies, f => new List<LnkMestToedieningsEmissy>())
            .RuleFor(v => v.LnkStalDierSubCategories, f => new List<LnkStalDierSubCategorie>())
            .RuleFor(v => v.LutCheckTypes, f => new List<LutCheckType>())
            .RuleFor(v => v.LutDierCategories, f => new List<LutDierCategorie>())
            .RuleFor(v => v.LutGewasGroeps, f => new List<LutGewasGroep>())
            .RuleFor(v => v.LutKunstmestGroeps, f => new List<LutKunstmestGroep>())
            .RuleFor(v => v.LutLandbouwStreeks, f => new List<LutLandbouwStreek>())
            .RuleFor(v => v.LutMestTypes, f => new List<LutMestType>())
            .RuleFor(v => v.LutMestverwerkingsTechnieks, f => new List<LutMestverwerkingsTechniek>())
            .RuleFor(v => v.LutStalTypes, f => new List<LutStalType>())
            .RuleFor(v => v.LutToedieningsPlaats, f => new List<LutToedieningsPlaat>())
            .RuleFor(v => v.LutToedieningsTechnieks, f => new List<LutToedieningsTechniek>())
            .RuleFor(v => v.TblChecks, f => new List<TblCheck>())
            .RuleFor(v => v.TblConvenants, f => new List<TblConvenant>())
            .RuleFor(v => v.TblDierSubCategories, f => new List<TblDierSubCategorie>())
            .RuleFor(v => v.TblParameters, f => new List<TblParameter>())
            .RuleFor(v => v.TblPas, f => new List<TblPas>())
            .RuleFor(v => v.TblRegressieRechtes, f => new List<TblRegressieRechte>())
            .RuleFor(v => v.TblRegressies, f => new List<TblRegressie>())
            .RuleFor(v => v.TblStals, f => new List<TblStal>());

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
                context.TblStals.Add(stal);
                var pas = tblPasData.Generate();
                context.TblPas.Add(pas);
                var versie = tblVersieData.Generate();
                context.TblVersies.Add(versie);
                var gewassenData = lnkGewassenData.Generate();
                context.LnkGewassens.Add(gewassenData);

            }
            Console.WriteLine("mock data generated");
            context.SaveChanges();
        }
            
    }
}