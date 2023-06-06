using Bogus;
using ilvo_automatisation.Models;

namespace ilvo_automatisation
{
    public class GenerateMockData
    {
        public void GenerateData()
        {
            var faker = new Faker("nl_BE");

            var tblPasData = new Faker<TblPas>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Naam, f => f.Name.FirstName())
                .RuleFor(p => p.ReductiePercentage, f => f.Random.Double(0, 100))
                .RuleFor(p => p.Passtal, f => f.Random.Bool())
                .RuleFor(p => p.Pasvoeding, f => f.Random.Bool())
                .RuleFor(p => p.Pasweide, f => f.Random.Bool())
                .RuleFor(p => p.VersieId, f => f.Random.Guid())
                .RuleFor(p => p.Versie, f => new TblVersie())
                .Generate(10);
            Console.WriteLine(tblPasData);

            var tblStalData = new Faker<TblStal>()
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.Naam, f => f.Company.CompanyName())
                .RuleFor(s => s.Omschrijving, f => f.Lorem.Sentence())
                .RuleFor(s => s.FractieVloeibaar, f => f.Random.Double())
                .RuleFor(s => s.ReductiePercentage, f => f.Random.Double())
                .RuleFor(s => s.MestTypeId, f => f.Random.Guid())
                .RuleFor(s => s.StalTypeId, f => f.Random.Guid())
                .RuleFor(s => s.VersieId, f => f.Random.Guid())
                .RuleFor(s => s.LnkStalDierSubCategories, f => new List<LnkStalDierSubCategorie>())
                .RuleFor(s => s.MestType, f => new LutMestType())
                .RuleFor(s => s.StalType, f => new LutStalType())
                .RuleFor(s => s.Versie, f => new TblVersie())
                .Generate(10);
            Console.WriteLine(tblStalData);


            var tblVersieData = new Faker<TblVersie>()
                .RuleFor(v => v.Id, f => f.Random.Guid())
                .RuleFor(v => v.Naam, f => f.Company.CompanyName())
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
                .RuleFor(v => v.TblStals, f => new List<TblStal>())
                .Generate(10);
            Console.WriteLine(tblVersieData);


            var lnkGewassenData = new Faker<LnkGewassen>()
                .RuleFor(g => g.Id, f => f.Random.Guid())
                .RuleFor(g => g.CodeHoofdTeelt, f => f.Random.Int(1, 100))
                .RuleFor(g => g.GewasGroepId, f => f.Random.Guid())
                .RuleFor(g => g.VersieId, f => f.Random.Guid())
                .RuleFor(g => g.OmsHoofdTeelt, f => f.Random.Words())
                .RuleFor(g => g.GewasGroepOogstrestId, f => f.Random.Guid())
                .RuleFor(g => g.GewasGroep, f => new LutGewasGroep())
                .RuleFor(g => g.Versie, f => new TblVersie())
                .Generate(10);
            Console.WriteLine(lnkGewassenData);

            using (var context = new IlvoDbContext())
            {
                context.TblPas.AddRange(tblPasData);
                context.TblStal.AddRange(tblStalData);
                context.TblVersie.AddRange(tblVersieData);
                context.LnkGewassen.AddRange(lnkGewassenData);

                context.SaveChanges();
            }
        }
    }
}
