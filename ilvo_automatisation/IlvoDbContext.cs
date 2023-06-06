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
    public DbSet<GeoOpslag> GeoOpslags { get; set; }
    public DbSet<GeoProvincie> GeoProvincies { get; set; }
    public DbSet<GeoStal> GeoStals { get; set; }
    public DbSet<GeoUitrijden> GeoUitrijdens { get; set; }
    public DbSet<GeoWeide> GeoWeides { get; set; }
    public DbSet<IdentExploitatie> IdentExploitaties { get; set; }
    public DbSet<LnkGewassen> LnkGewassens { get; set; }
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
    public DbSet<Stallen> Stallens { get; set; }
    public DbSet<TblCheck> TblChecks { get; set; }
    public DbSet<TblConvenant> TblConvenants { get; set; }
    public DbSet<TblDierSubCategorie> TblDierSubCategories { get; set; }
    public DbSet<TblGebruiker> TblGebruikers { get; set; }
    public DbSet<TblParameter> TblParameters { get; set; }
    public DbSet<TblPas> TblPas { get; set; }
    public DbSet<TblRegressie> TblRegressies { get; set; }
    public DbSet<TblRegressieRechte> TblRegressieRechtes { get; set; }
    public DbSet<TblStal> TblStals { get; set; }
    public DbSet<TblVersie> TblVersies { get; set; }
    public DbSet<VervoerMad> VervoerMads { get; set; }
    public DbSet<Vlops1000mRooster> Vlops1000MRoosters { get; set; }
    public DbSet<Vlops250mRooster> Vlops250MRoosters { get; set; }

    public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
    {
    }

    // Override OnModelCreating if you need to configure your entity models
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureEntity<LutGewasGroep>(modelBuilder);
        ConfigureEntity<AangifteDierStalPas>(modelBuilder);
        ConfigureEntity<Bemesting>(modelBuilder);
        ConfigureEntity<BuiVlaOpslverschil>(modelBuilder);
        ConfigureEntity<Burenregelingen>(modelBuilder);
        ConfigureEntity<BurenregelingenEff>(modelBuilder);
        ConfigureEntity<BuTransportVracht>(modelBuilder);
        ConfigureEntity<BuTransportVrachtEff>(modelBuilder);
        ConfigureEntity<CoSlib>(modelBuilder);
        ConfigureEntity<DierProd>(modelBuilder);
        ConfigureEntity<EmavContext>(modelBuilder);
        ConfigureEntity<EvoaAanbieder>(modelBuilder);
        ConfigureEntity<Exploitatie>(modelBuilder);
        ConfigureEntity<GebruikKm>(modelBuilder);
        ConfigureEntity<GeoEmissieGemeente>(modelBuilder);
        ConfigureEntity<GeoEmissieGemeente2019>(modelBuilder);
        ConfigureEntity<GeoEmissieMestverwerking>(modelBuilder);
        ConfigureEntity<GeoEmissieVlops1000>(modelBuilder);
        ConfigureEntity<GeoEmissieVlops250>(modelBuilder);
        ConfigureEntity<GeoExploitatie>(modelBuilder);
        ConfigureEntity<GeoMestverwerking>(modelBuilder);
        ConfigureEntity<GeometryColumn>(modelBuilder);
        ConfigureEntity<GeoOpslag>(modelBuilder);
        ConfigureEntity<GeoProvincie>(modelBuilder);
        ConfigureEntity<GeoStal>(modelBuilder);
        ConfigureEntity<GeoUitrijden>(modelBuilder);
        ConfigureEntity<GeoWeide>(modelBuilder);
        ConfigureEntity<IdentExploitatie>(modelBuilder);
        ConfigureEntity<LnkGewassen>(modelBuilder);
        //ConfigureEntity<LnkGewassen1>(modelBuilder);
        ConfigureEntity<LnkKunstmest>(modelBuilder);
        ConfigureEntity<LnkKunstmestGroepStreek>(modelBuilder);
        ConfigureEntity<LnkMestDierPlaat>(modelBuilder);
        ConfigureEntity<LnkMestTechniekPlaat>(modelBuilder);
        ConfigureEntity<LnkMestToedieningsEmissy>(modelBuilder);
        ConfigureEntity<LnkStalDierSubCategorie>(modelBuilder);
        ConfigureEntity<LutCheckType>(modelBuilder);
        ConfigureEntity<LutDierCategorie>(modelBuilder);
        ConfigureEntity<LutGewasGroep>(modelBuilder);
        ConfigureEntity<LutKunstmestGroep>(modelBuilder);
        ConfigureEntity<LutLandbouwStreek>(modelBuilder);
        ConfigureEntity<LutMestType>(modelBuilder);
        ConfigureEntity<LutMestverwerkingsTechniek>(modelBuilder);
        ConfigureEntity<LutStalType>(modelBuilder);
        ConfigureEntity<LutToedieningsPlaat>(modelBuilder);
        ConfigureEntity<LutToedieningsTechniek>(modelBuilder);
        ConfigureEntity<MvwUitbatingActiviteit>(modelBuilder);
        ConfigureEntity<MvwUitbatingAdressen>(modelBuilder);
        ConfigureEntity<SpatialRefSy>(modelBuilder);
        ConfigureEntity<Stallen>(modelBuilder);
        ConfigureEntity<TblCheck>(modelBuilder);
        ConfigureEntity<TblConvenant>(modelBuilder);
        ConfigureEntity<TblDierSubCategorie>(modelBuilder);
        ConfigureEntity<TblGebruiker>(modelBuilder);
        ConfigureEntity<TblParameter>(modelBuilder);
        ConfigureEntity<TblPas>(modelBuilder);
        //ConfigureEntity<TblPas1>(modelBuilder);
        ConfigureEntity<TblRegressie>(modelBuilder);
        ConfigureEntity<TblRegressieRechte>(modelBuilder);
        ConfigureEntity<TblStal>(modelBuilder);
        //ConfigureEntity<TblStal1>(modelBuilder);
        ConfigureEntity<TblVersie>(modelBuilder);
        //ConfigureEntity<TblVersie1>(modelBuilder);
        ConfigureEntity<VervoerMad>(modelBuilder);
        ConfigureEntity<Vlops1000mRooster>(modelBuilder);
        ConfigureEntity<Vlops250mRooster>(modelBuilder);
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

    private static void ConfigureEntity<T>(ModelBuilder modelBuilder) where T : class
    {
        modelBuilder.Entity<T>().ToTable(typeof(T).Name);
    }
}