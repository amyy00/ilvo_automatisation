using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation;

public class IlvoDbContext : DbContext
{
    public DbSet<AangifteDierStalPas> AangifteDierStalPas { get; set; }
    public DbSet<Bemesting> Bemestings { get; set; }
    public DbSet<BuiVlaOpslverschil> BuiVlaOpslverschils { get; set; }
    public DbSet<Burenregelingen> Burenregelingens { get; set; }
    public DbSet<BurenregelingenEff> BurenregelingenEffs { get; set; }
    public DbSet<BuTransportVracht> BuTransportVrachts { get; set; }
    public DbSet<BuTransportVrachtEff> BuTransportVrachtEffs { get; set; }
    public DbSet<CoSlib> CoSlibs { get; set; }
    public DbSet<DierProd> DierProds { get; set; }
    public DbSet<EmavContext> EmavContexts { get; set; }
    public DbSet<EvoaAanbieder> EvoaAanbieders { get; set; }
    public DbSet<Exploitatie> Exploitaties { get; set; }
    public DbSet<GebruikKm> GebruikKms { get; set; }
    public DbSet<GeoEmissieGemeente> GeoEmissieGemeentes { get; set; }
    public DbSet<GeoEmissieGemeente2019> GeoEmissieGemeente2019s { get; set; }
    public DbSet<GeoEmissieMestverwerking> GeoEmissieMestverwerkings { get; set; }
    public DbSet<GeoEmissieVlops1000> GeoEmissieVlops1000s { get; set; }
    public DbSet<GeoEmissieVlops250> GeoEmissieVlops250s { get; set; }
    public DbSet<GeoExploitatie> GeoExploitaties { get; set; }
    public DbSet<GeoMestverwerking> GeoMestverwerkings { get; set; }
    public DbSet<GeometryColumn> GeometryColumns { get; set; }
    public DbSet<GeoOpslag> GeoOpslags { get; set; }
    public DbSet<GeoProvincie> GeoProvincies { get; set; }
    public DbSet<GeoStal> GeoStals { get; set; }
    public DbSet<GeoUitrijden> GeoUitrijdens { get; set; }
    public DbSet<GeoWeide> GeoWeides { get; set; }
    public DbSet<IdentExploitatie> IdentExploitaties { get; set; }
    public DbSet<LnkGewassen> LnkGewassens { get; set; }
    public DbSet<LnkGewassen1> LnkGewassen1s { get; set; }
    public DbSet<LnkKunstmest> LnkKunstmests { get; set; }
    public DbSet<LnkKunstmestGroepStreek> LnkKunstmestGroepStreeks { get; set; }
    public DbSet<LnkMestDierPlaat> LnkMestDierPlaats { get; set; }
    public DbSet<LnkMestTechniekPlaat> LnkMestTechniekPlaats { get; set; }
    public DbSet<LnkMestToedieningsEmissy> LnkMestToedieningsEmissies { get; set; }
    public DbSet<LnkStalDierSubCategorie> LnkStalDierSubCategories { get; set; }
    public DbSet<LutCheckType> LutCheckTypes { get; set; }
    public DbSet<LutDierCategorie> LutDierCategories { get; set; }
    public DbSet<LutGewasGroep> LutGewasGroeps { get; set; }
    public DbSet<LutKunstmestGroep> LutKunstmestGroeps { get; set; }
    public DbSet<LutLandbouwStreek> LutLandbouwStreeks { get; set; }
    public DbSet<LutMestType> LutMestTypes { get; set; }
    public DbSet<LutMestverwerkingsTechniek> LutMestverwerkingsTechnieks { get; set; }
    public DbSet<LutStalType> LutStalTypes { get; set; }
    public DbSet<LutToedieningsPlaat> LutToedieningsPlaats { get; set; }
    public DbSet<LutToedieningsTechniek> LutToedieningsTechnieks { get; set; }
    public DbSet<MvwUitbatingActiviteit> MvwUitbatingActiviteits { get; set; }
    public DbSet<MvwUitbatingAdressen> MvwUitbatingAdressens { get; set; }
    public DbSet<SpatialRefSy> SpatialRefSies { get; set; }
    public DbSet<Stallen> Stallens { get; set; }
    public DbSet<TblCheck> TblChecks { get; set; }
    public DbSet<TblConvenant> TblConvenants { get; set; }
    public DbSet<TblDierSubCategorie> TblDierSubCategories { get; set; }
    public DbSet<TblGebruiker> TblGebruikers { get; set; }
    public DbSet<TblParameter> TblParameters { get; set; }
    public DbSet<TblPas> TblPas { get; set; }
    public DbSet<TblPas1> TblPas1s { get; set; }
    public DbSet<TblRegressie> TblRegressies { get; set; }
    public DbSet<TblRegressieRechte> TblRegressieRechtes { get; set; }
    public DbSet<TblStal> TblStals { get; set; }
    public DbSet<TblStal1> TblStal1s { get; set; }
    public DbSet<TblVersie> TblVersies { get; set; }
    public DbSet<TblVersie1> TblVersie1s { get; set; }
    public DbSet<VervoerMad> VervoerMads { get; set; }
    public DbSet<Vlops1000mRooster> Vlops1000MRoosters { get; set; }
    public DbSet<Vlops250mRooster> Vlops250MRoosters { get; set; }
    
    public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
    {
    }

    // Override OnModelCreating if you need to configure your entity models
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    // Optional: Override OnConfiguring if you want to provide configuration options
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure database provider, connection string, etc.
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Constants.connectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    // Custom Set method to retrieve DbSet dynamically
    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }
}