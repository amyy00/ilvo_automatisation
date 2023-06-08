using ilvo_automatisation.Data;
using Microsoft.EntityFrameworkCore;

namespace ilvo_automatisation.Models;

public partial class EmavContext : DbContext
{
    public EmavContext()
    {
    }

    public EmavContext(DbContextOptions<EmavContext> options) : base(options)
    {
    }

    public virtual DbSet<AangifteDierStalPas> AangifteDierStalPas { get; set; }

    public virtual DbSet<Bemesting> Bemesting { get; set; }

    public virtual DbSet<BuTransportVracht> BuTransportVracht { get; set; }

    public virtual DbSet<BuTransportVrachtEff> BuTransportVrachtEff { get; set; }

    public virtual DbSet<BuiVlaOpslverschil> BuiVlaOpslverschil { get; set; }

    public virtual DbSet<Burenregelingen> Burenregelingen { get; set; }

    public virtual DbSet<BurenregelingenEff> BurenregelingenEff { get; set; }

    public virtual DbSet<CoSlib> CoSlib { get; set; }

    public virtual DbSet<DierProd> DierProd { get; set; }

    public virtual DbSet<EvoaAanbieder> EvoaAanbieder { get; set; }

    public virtual DbSet<Exploitatie> Exploitatie { get; set; }

    public virtual DbSet<GebruikKm> GebruikKm { get; set; }

    public virtual DbSet<GeoEmissieGemeente> GeoEmissieGemeente { get; set; }

    public virtual DbSet<GeoEmissieGemeente2019> GeoEmissieGemeente2019 { get; set; }

    public virtual DbSet<GeoEmissieMestverwerking> GeoEmissieMestverwerking { get; set; }

    public virtual DbSet<GeoEmissieVlops1000> GeoEmissieVlops1000 { get; set; }

    public virtual DbSet<GeoEmissieVlops250> GeoEmissieVlops250 { get; set; }

    public virtual DbSet<GeoExploitatie> GeoExploitatie { get; set; }

    public virtual DbSet<GeoMestverwerking> GeoMestverwerking { get; set; }

    public virtual DbSet<GeoOpslag> GeoOpslag { get; set; }

    public virtual DbSet<GeoProvincie> GeoProvincie { get; set; }

    public virtual DbSet<GeoStal> GeoStal { get; set; }

    public virtual DbSet<GeoUitrijden> GeoUitrijden { get; set; }

    public virtual DbSet<GeoWeide> GeoWeide { get; set; }

    public virtual DbSet<GeometryColumn> GeometryColumn { get; set; }

    public virtual DbSet<IdentExploitatie> IdentExploitatie { get; set; }

    public virtual DbSet<LnkGewassen> LnkGewassen { get; set; }

    public virtual DbSet<LnkKunstmest> LnkKunstmest { get; set; }

    public virtual DbSet<LnkKunstmestGroepStreek> LnkKunstmestGroepStreek { get; set; }

    public virtual DbSet<LnkMestDierPlaat> LnkMestDierPlaat { get; set; }

    public virtual DbSet<LnkMestTechniekPlaat> LnkMestTechniekPlaat { get; set; }

    public virtual DbSet<LnkMestToedieningsEmissy> LnkMestToedieningsEmissie { get; set; }

    public virtual DbSet<LnkStalDierSubCategorie> LnkStalDierSubCategorie { get; set; }

    public virtual DbSet<LutCheckType> LutCheckType { get; set; }

    public virtual DbSet<LutDierCategorie> LutDierCategorie { get; set; }

    public virtual DbSet<LutGewasGroep> LutGewasGroep { get; set; }

    public virtual DbSet<LutKunstmestGroep> LutKunstmestGroep { get; set; }

    public virtual DbSet<LutLandbouwStreek> LutLandbouwStreek { get; set; }

    public virtual DbSet<LutMestType> LutMestType { get; set; }

    public virtual DbSet<LutMestverwerkingsTechniek> LutMestverwerkingsTechniek { get; set; }

    public virtual DbSet<LutStalType> LutStalType { get; set; }

    public virtual DbSet<LutToedieningsPlaat> LutToedieningsPlaat { get; set; }

    public virtual DbSet<LutToedieningsTechniek> LutToedieningsTechniek { get; set; }

    public virtual DbSet<MvwUitbatingActiviteit> MvwUitbatingActiviteit { get; set; }

    public virtual DbSet<MvwUitbatingAdressen> MvwUitbatingAdressen { get; set; }

    public virtual DbSet<SpatialRefSy> SpatialRefSy { get; set; }

    public virtual DbSet<Stallen> Stallen { get; set; }

    public virtual DbSet<TblCheck> TblCheck { get; set; }

    public virtual DbSet<TblConvenant> TblConvenant { get; set; }

    public virtual DbSet<TblDierSubCategorie> TblDierSubCategorie { get; set; }

    public virtual DbSet<TblGebruiker> TblGebruiker { get; set; }

    public virtual DbSet<TblPas> TblPas { get; set; }

    public virtual DbSet<TblParameter> TblParameter { get; set; }

    public virtual DbSet<TblRegressie> TblRegressie { get; set; }

    public virtual DbSet<TblRegressieRechte> TblRegressieRechte { get; set; }

    public virtual DbSet<TblStal> TblStal { get; set; }

    public virtual DbSet<TblVersie> TblVersie { get; set; }

    public virtual DbSet<VervoerMad> VervoerMad { get; set; }

    public virtual DbSet<Vlops1000mRooster> Vlops1000mRooster { get; set; }

    public virtual DbSet<Vlops250mRooster> Vlops250mRoosters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure database provider, connection string, etc.
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Constants.connectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AangifteDierStalPas>(entity =>
        {
            entity.ToTable("AANGIFTE_DIER_STAL_PAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AanBezettingPasMaatregel)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("AAN_BEZETTING_PAS_MAATREGEL");
            entity.Property(e => e.CodeDiergroep)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERGROEP");
            entity.Property(e => e.CodeDiersoort)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERSOORT");
            entity.Property(e => e.CodeStaltype)
                .HasMaxLength(10)
                .HasColumnName("CODE_STALTYPE");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.NrVersie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("NR_VERSIE");
            entity.Property(e => e.OmsDiergroep)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERGROEP");
            entity.Property(e => e.OmsDiersoort)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERSOORT");
            entity.Property(e => e.OmsPasMaatregel)
                .HasMaxLength(150)
                .HasColumnName("OMS_PAS_MAATREGEL");
            entity.Property(e => e.OmsStaltype)
                .HasMaxLength(120)
                .HasColumnName("OMS_STALTYPE");
        });

        modelBuilder.Entity<Bemesting>(entity =>
        {
            entity.ToTable("BEMESTING");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoGewasHoofdteelt).HasColumnName("CO_GEWAS_HOOFDTEELT");
            entity.Property(e => e.CoGroepGewasMb).HasColumnName("CO_GROEP_GEWAS_MB");
            entity.Property(e => e.CoGroepGewasNMb).HasColumnName("CO_GROEP_GEWAS_N_MB");
            entity.Property(e => e.CoProductiemethode)
                .HasMaxLength(25)
                .HasColumnName("CO_PRODUCTIEMETHODE");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.IdLbPerceel)
                .HasMaxLength(30)
                .HasColumnName("ID_LB_PERCEEL");
            entity.Property(e => e.IndGebruik0101)
                .HasMaxLength(5)
                .HasColumnName("IND_GEBRUIK0101");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NmGemeenteBestand)
                .HasMaxLength(25)
                .HasColumnName("NM_GEMEENTE_BESTAND");
            entity.Property(e => e.NmGemeenteBestand1)
                .HasMaxLength(25)
                .HasColumnName("NM_GEMEENTE_BESTAND1");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.NrSeqPerceel).HasColumnName("NR_SEQ_PERCEEL");
            entity.Property(e => e.OmsGewasHoofdteelt)
                .HasMaxLength(255)
                .HasColumnName("OMS_GEWAS_HOOFDTEELT");
            entity.Property(e => e.OmsGroepGewasMb)
                .HasMaxLength(255)
                .HasColumnName("OMS_GROEP_GEWAS_MB");
            entity.Property(e => e.OmsGroepGewasNMb)
                .HasMaxLength(255)
                .HasColumnName("OMS_GROEP_GEWAS_N_MB");
            entity.Property(e => e.OmsLandbouwstreek)
                .HasMaxLength(20)
                .HasColumnName("OMS_LANDBOUWSTREEK");
            entity.Property(e => e.OppHaNetto)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("OPP_HA_NETTO");
            entity.Property(e => e.XLabel)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("X_LABEL");
            entity.Property(e => e.YLabel)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("Y_LABEL");
        });

        modelBuilder.Entity<BuTransportVracht>(entity =>
        {
            entity.ToTable("BU_TRANSPORT_VRACHT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoMest).HasColumnName("CO_MEST");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.CoNisGemeenteLospl)
                .HasMaxLength(25)
                .HasColumnName("CO_NIS_GEMEENTE_LOSPL");
            entity.Property(e => e.CoRolAfn)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_AFN");
            entity.Property(e => e.CoRolAnb)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_ANB");
            entity.Property(e => e.CoToestand)
                .HasMaxLength(10)
                .HasColumnName("CO_TOESTAND");
            entity.Property(e => e.CoToestandVracht)
                .HasMaxLength(10)
                .HasColumnName("CO_TOESTAND_VRACHT");
            entity.Property(e => e.DaNamelding)
                .HasColumnType("datetime")
                .HasColumnName("DA_NAMELDING");
            entity.Property(e => e.GwKgNVracht).HasColumnName("GW_KG_N_VRACHT");
            entity.Property(e => e.GwTonNameldingVracht).HasColumnName("GW_TON_NAMELDING_VRACHT");
            entity.Property(e => e.JrBurenregeling).HasColumnName("JR_BURENREGELING");
            entity.Property(e => e.NmGemeenteLospl)
                .HasMaxLength(255)
                .HasColumnName("NM_GEMEENTE_LOSPL");
            entity.Property(e => e.NrBurenregeling).HasColumnName("NR_BURENREGELING");
            entity.Property(e => e.NrExploitantAfnFict).HasColumnName("NR_EXPLOITANT_AFN_FICT");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAfnFict).HasColumnName("NR_EXPLOITATIE_AFN_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAfnFict).HasColumnName("NR_LANDBOUWER_AFN_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.UitbatersnummerAfnFict).HasColumnName("UITBATERSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatersnummerAnbFict).HasColumnName("UITBATERSNUMMER_ANB_FICT");
            entity.Property(e => e.UitbatingsnummerAfnFict).HasColumnName("UITBATINGSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatingsnummerAnbFict).HasColumnName("UITBATINGSNUMMER_ANB_FICT");
            entity.Property(e => e.VolgnrVracht).HasColumnName("VOLGNR_VRACHT");
        });

        modelBuilder.Entity<BuTransportVrachtEff>(entity =>
        {
            entity.ToTable("BU_TRANSPORT_VRACHT_EFF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoMest).HasColumnName("CO_MEST");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.CoNisGemeenteLospl)
                .HasMaxLength(25)
                .HasColumnName("CO_NIS_GEMEENTE_LOSPL");
            entity.Property(e => e.CoRolAfn)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_AFN");
            entity.Property(e => e.CoRolAnb)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_ANB");
            entity.Property(e => e.CoToestand)
                .HasMaxLength(10)
                .HasColumnName("CO_TOESTAND");
            entity.Property(e => e.CoToestandVracht)
                .HasMaxLength(10)
                .HasColumnName("CO_TOESTAND_VRACHT");
            entity.Property(e => e.DaNamelding)
                .HasColumnType("datetime")
                .HasColumnName("DA_NAMELDING");
            entity.Property(e => e.GwKgNVracht).HasColumnName("GW_KG_N_VRACHT");
            entity.Property(e => e.GwTonNameldingVracht).HasColumnName("GW_TON_NAMELDING_VRACHT");
            entity.Property(e => e.JrBurenregeling).HasColumnName("JR_BURENREGELING");
            entity.Property(e => e.NmGemeenteLospl)
                .HasMaxLength(255)
                .HasColumnName("NM_GEMEENTE_LOSPL");
            entity.Property(e => e.NrBurenregeling).HasColumnName("NR_BURENREGELING");
            entity.Property(e => e.NrExploitantAfnFict).HasColumnName("NR_EXPLOITANT_AFN_FICT");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAfnFict).HasColumnName("NR_EXPLOITATIE_AFN_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAfnFict).HasColumnName("NR_LANDBOUWER_AFN_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.UitbatersnummerAfnFict).HasColumnName("UITBATERSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatersnummerAnbFict).HasColumnName("UITBATERSNUMMER_ANB_FICT");
            entity.Property(e => e.UitbatingsnummerAfnFict).HasColumnName("UITBATINGSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatingsnummerAnbFict).HasColumnName("UITBATINGSNUMMER_ANB_FICT");
            entity.Property(e => e.VolgnrVracht).HasColumnName("VOLGNR_VRACHT");
        });

        modelBuilder.Entity<BuiVlaOpslverschil>(entity =>
        {
            entity.ToTable("BUI_VLA_OPSLVERSCHIL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.GwKgNEigenafzetBuiVla).HasColumnName("GW_KG_N_EIGENAFZET_BUI_VLA");
            entity.Property(e => e.GwKgNGebruikChemBuiVla).HasColumnName("GW_KG_N_GEBRUIK_CHEM_BUI_VLA");
            entity.Property(e => e.GwKgNGebruikDierBuiVla).HasColumnName("GW_KG_N_GEBRUIK_DIER_BUI_VLA");
            entity.Property(e => e.GwKgNOpslagverschilDier).HasColumnName("GW_KG_N_OPSLAGVERSCHIL_DIER");
            entity.Property(e => e.JrProductie).HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
        });

        modelBuilder.Entity<Burenregelingen>(entity =>
        {
            entity.ToTable("BURENREGELINGEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoMest).HasColumnName("CO_MEST");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.CoNisGemeenteLospl)
                .HasMaxLength(25)
                .HasColumnName("CO_NIS_GEMEENTE_LOSPL");
            entity.Property(e => e.CoRolAfn)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_AFN");
            entity.Property(e => e.CoRolAnb)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_ANB");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.GwKgN).HasColumnName("GW_KG_N");
            entity.Property(e => e.JrBurenregeling).HasColumnName("JR_BURENREGELING");
            entity.Property(e => e.NmGemeenteLospl)
                .HasMaxLength(255)
                .HasColumnName("NM_GEMEENTE_LOSPL");
            entity.Property(e => e.NrBurenregeling).HasColumnName("NR_BURENREGELING");
            entity.Property(e => e.NrExploitantAfnFict).HasColumnName("NR_EXPLOITANT_AFN_FICT");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAfnFict).HasColumnName("NR_EXPLOITATIE_AFN_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAfnFict).HasColumnName("NR_LANDBOUWER_AFN_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.UitbatersnummerAfnFict).HasColumnName("UITBATERSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatersnummerAnbFict).HasColumnName("UITBATERSNUMMER_ANB_FICT");
            entity.Property(e => e.UitbatingsnummerAfnFict).HasColumnName("UITBATINGSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatingsnummerAnbFict).HasColumnName("UITBATINGSNUMMER_ANB_FICT");
        });

        modelBuilder.Entity<BurenregelingenEff>(entity =>
        {
            entity.ToTable("BURENREGELINGEN_EFF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoMest).HasColumnName("CO_MEST");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.CoNisGemeenteLospl)
                .HasMaxLength(25)
                .HasColumnName("CO_NIS_GEMEENTE_LOSPL");
            entity.Property(e => e.CoRolAfn)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_AFN");
            entity.Property(e => e.CoRolAnb)
                .HasMaxLength(25)
                .HasColumnName("CO_ROL_ANB");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.GwKgN).HasColumnName("GW_KG_N");
            entity.Property(e => e.JrBurenregeling).HasColumnName("JR_BURENREGELING");
            entity.Property(e => e.NmGemeenteLospl)
                .HasMaxLength(255)
                .HasColumnName("NM_GEMEENTE_LOSPL");
            entity.Property(e => e.NrBurenregeling).HasColumnName("NR_BURENREGELING");
            entity.Property(e => e.NrExploitantAfnFict).HasColumnName("NR_EXPLOITANT_AFN_FICT");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAfnFict).HasColumnName("NR_EXPLOITATIE_AFN_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAfnFict).HasColumnName("NR_LANDBOUWER_AFN_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.UitbatersnummerAfnFict).HasColumnName("UITBATERSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatersnummerAnbFict).HasColumnName("UITBATERSNUMMER_ANB_FICT");
            entity.Property(e => e.UitbatingsnummerAfnFict).HasColumnName("UITBATINGSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatingsnummerAnbFict).HasColumnName("UITBATINGSNUMMER_ANB_FICT");
        });

        modelBuilder.Entity<CoSlib>(entity =>
        {
            entity.ToTable("CO_SLIB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Afkomst)
                .HasMaxLength(50)
                .HasColumnName("AFKOMST");
            entity.Property(e => e.CoMest).HasColumnName("co_mest");
            entity.Property(e => e.CoMest2)
                .HasMaxLength(4)
                .HasColumnName("co_mest2");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.Dierlijk).HasColumnName("dierlijk");
            entity.Property(e => e.GegrAfkomst)
                .HasMaxLength(30)
                .HasColumnName("gegr_afkomst");
            entity.Property(e => e.IndEffluent).HasColumnName("ind_effluent");
            entity.Property(e => e.Overm).HasColumnName("overm");
            entity.Property(e => e.Pluimm).HasColumnName("pluimm");
            entity.Property(e => e.Slib).HasColumnName("slib");
            entity.Property(e => e.Varkm).HasColumnName("varkm");
        });

        modelBuilder.Entity<DierProd>(entity =>
        {
            entity.ToTable("DIER_PROD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AanBezettingDiersoort)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AAN_BEZETTING_DIERSOORT");
            entity.Property(e => e.BrutoProductieN)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("BRUTO_PRODUCTIE_N");
            entity.Property(e => e.CodeDiergroep)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERGROEP");
            entity.Property(e => e.CodeDiersoort)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERSOORT");
            entity.Property(e => e.CodeDiersoortMelkkoe)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERSOORT_MELKKOE");
            entity.Property(e => e.CodeNub)
                .HasMaxLength(10)
                .HasColumnName("CODE_NUB");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.EmissieverliesDiersoort)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("EMISSIEVERLIES_DIERSOORT");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NettoProductieN)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("NETTO_PRODUCTIE_N");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.OmsDiergroep)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERGROEP");
            entity.Property(e => e.OmsDiersoort)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERSOORT");
            entity.Property(e => e.OmsNub)
                .HasMaxLength(100)
                .HasColumnName("OMS_NUB");
        });

        modelBuilder.Entity<EvoaAanbieder>(entity =>
        {
            entity.ToTable("EVOA_AANBIEDER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoIdentEenhRolAanbieder)
                .HasMaxLength(25)
                .HasColumnName("CO_IDENT_EENH_ROL_AANBIEDER");
            entity.Property(e => e.CoMest).HasColumnName("CO_MEST");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.GwKgNVnEvoaAfvoer).HasColumnName("GW_KG_N_VN_EVOA_AFVOER");
            entity.Property(e => e.JrEvVervoer).HasColumnName("JR_EV_VERVOER");
            entity.Property(e => e.NmMestvorm)
                .HasMaxLength(20)
                .HasColumnName("NM_MESTVORM");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.OmsMest)
                .HasMaxLength(20)
                .HasColumnName("OMS_MEST");
            entity.Property(e => e.UitbatersnummerAanbiederFict).HasColumnName("UITBATERSNUMMER_AANBIEDER_FICT");
            entity.Property(e => e.UitbatingsnummerAanbiederFict).HasColumnName("UITBATINGSNUMMER_AANBIEDER_FICT");
        });

        modelBuilder.Entity<Exploitatie>(entity =>
        {
            entity.ToTable("EXPLOITATIE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodeBemestingssysteem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CODE_BEMESTINGSSYSTEEM");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.GwKgNBuAanvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_BU_AANVOER_DIER");
            entity.Property(e => e.GwKgNBuAfvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_BU_AFVOER_DIER");
            entity.Property(e => e.GwKgNEvoaAanvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_EVOA_AANVOER_DIER");
            entity.Property(e => e.GwKgNEvoaAfvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_EVOA_AFVOER_DIER");
            entity.Property(e => e.GwKgNGebruikChem)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_GEBRUIK_CHEM");
            entity.Property(e => e.GwKgNInschaarAanvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_INSCHAAR_AANVOER_DIER");
            entity.Property(e => e.GwKgNInschaarAfvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_INSCHAAR_AFVOER_DIER");
            entity.Property(e => e.GwKgNMadAanvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_MAD_AANVOER_DIER");
            entity.Property(e => e.GwKgNMadAfvoerDier)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("GW_KG_N_MAD_AFVOER_DIER");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
        });

        modelBuilder.Entity<GebruikKm>(entity =>
        {
            entity.ToTable("GEBRUIK_KM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoMeststof).HasColumnName("CO_MESTSTOF");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.GwKgN).HasColumnName("GW_KG_N");
            entity.Property(e => e.GwKgP).HasColumnName("GW_KG_P");
            entity.Property(e => e.IndSerre)
                .HasMaxLength(1)
                .HasColumnName("IND_SERRE");
            entity.Property(e => e.JrProductie).HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.OmsMeststofLang)
                .HasMaxLength(50)
                .HasColumnName("OMS_MESTSTOF_LANG");
        });

        modelBuilder.Entity<GeoEmissieGemeente>(entity =>
        {
            entity.ToTable("geoEmissieGemeente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(255);
            entity.Property(e => e.ProvincieId).HasColumnName("ProvincieID");

            entity.HasOne(d => d.Provincie).WithMany(p => p.GeoEmissieGemeentes)
                .HasForeignKey(d => d.ProvincieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_geoEmissieGemeente_geoProvincie");
        });

        modelBuilder.Entity<GeoEmissieGemeente2019>(entity =>
        {
            entity.ToTable("geoEmissieGemeente_2019");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(255);
            entity.Property(e => e.ProvincieId).HasColumnName("ProvincieID");

            entity.HasOne(d => d.Provincie).WithMany(p => p.GeoEmissieGemeente2019s)
                .HasForeignKey(d => d.ProvincieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_geoEmissieGemeente_2019_geoProvincie");
        });

        modelBuilder.Entity<GeoEmissieMestverwerking>(entity =>
        {
            entity.ToTable("geoEmissieMestverwerking");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
        });

        modelBuilder.Entity<GeoEmissieVlops1000>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_geoVlops1000");

            entity.ToTable("geoEmissieVlops1000");

            entity.HasIndex(e => e.VlopsId, "IX_geoEmissieVlops1000").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.VlopsId).HasColumnName("VlopsID");
        });

        modelBuilder.Entity<GeoEmissieVlops250>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_geoVlops250");

            entity.ToTable("geoEmissieVlops250");

            entity.HasIndex(e => e.VlopsId, "IX_geoEmissieVlops250").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.VlopsId).HasColumnName("VlopsID");
        });

        modelBuilder.Entity<GeoExploitatie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_geoExploitatie_1");

            entity.ToTable("geoExploitatie");

            entity.HasIndex(e => new { e.Exploitant, e.Exploitatie, e.Landbouwer }, "geoExploitant_Exploitatie_Landbouwer").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
            entity.Property(e => e.Niscode).HasColumnName("NISCode");
        });

        modelBuilder.Entity<GeoMestverwerking>(entity =>
        {
            entity.ToTable("geoMestverwerking");

            entity.HasIndex(e => new { e.Uitbating, e.Uitbater }, "geoMestverwerking_Uitbating_Uitbater").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BeginDatum).HasColumnType("datetime");
            entity.Property(e => e.EindDatum).HasColumnType("datetime");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
            entity.Property(e => e.Niscode).HasColumnName("NISCode");
        });

        modelBuilder.Entity<GeoOpslag>(entity =>
        {
            entity.ToTable("geoOpslag");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
        });

        modelBuilder.Entity<GeoProvincie>(entity =>
        {
            entity.ToTable("geoProvincie");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(100);
        });

        modelBuilder.Entity<GeoStal>(entity =>
        {
            entity.ToTable("geoStal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
        });

        modelBuilder.Entity<GeoUitrijden>(entity =>
        {
            entity.ToTable("geoUitrijden");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
        });

        modelBuilder.Entity<GeoWeide>(entity =>
        {
            entity.ToTable("geoWeide");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gemeente).HasMaxLength(255);
        });

        modelBuilder.Entity<GeometryColumn>(entity =>
        {
            entity.HasKey(e => new { e.FTableCatalog, e.FTableSchema, e.FTableName, e.FGeometryColumn }).HasName("geometry_columns_pk");

            entity.ToTable("geometry_columns");

            entity.Property(e => e.FTableCatalog)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("f_table_catalog");
            entity.Property(e => e.FTableSchema)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("f_table_schema");
            entity.Property(e => e.FTableName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("f_table_name");
            entity.Property(e => e.FGeometryColumn)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("f_geometry_column");
            entity.Property(e => e.CoordDimension).HasColumnName("coord_dimension");
            entity.Property(e => e.GeometryType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("geometry_type");
            entity.Property(e => e.Srid).HasColumnName("srid");
        });

        modelBuilder.Entity<IdentExploitatie>(entity =>
        {
            entity.ToTable("IDENT_EXPLOITATIE");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.CoNisFusiegemeente).HasColumnName("CO_NIS_FUSIEGEMEENTE");
            entity.Property(e => e.DaBeginIe)
                .HasColumnType("datetime")
                .HasColumnName("DA_BEGIN_IE");
            entity.Property(e => e.DaEindeIe)
                .HasColumnType("datetime")
                .HasColumnName("DA_EINDE_IE");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.DatumAflading)
                .HasColumnType("datetime")
                .HasColumnName("DATUM_AFLADING");
            entity.Property(e => e.LandCoPostGemExploitatieUit)
                .HasMaxLength(100)
                .HasColumnName("LAND_CO_POST_GEM_EXPLOITATIE_UIT");
            entity.Property(e => e.LinkIvo)
                .HasMaxLength(25)
                .HasColumnName("LINK_IVO");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.OmsFusiegemeente)
                .HasMaxLength(255)
                .HasColumnName("OMS_FUSIEGEMEENTE");
            entity.Property(e => e.StraatNrBusExploitatieUitbat)
                .HasMaxLength(100)
                .HasColumnName("STRAAT_NR_BUS_EXPLOITATIE_UITBAT");
        });

        modelBuilder.Entity<LnkGewassen>(entity =>
        {
            entity.ToTable("lnkGewassen", tb =>
                {
                    tb.HasTrigger("lnkGewassenTrigger_DELETE");
                    tb.HasTrigger("lnkGewassenTrigger_UPDATE");
                });

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.GewasGroepId).HasColumnName("GewasGroepID");
            entity.Property(e => e.GewasGroepOogstrestId).HasColumnName("GewasGroepOogstrestID");
            entity.Property(e => e.OmsHoofdTeelt).HasMaxLength(100);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.GewasGroep).WithMany(p => p.LnkGewassen)
                .HasForeignKey(d => d.GewasGroepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkGewassen_lutGewasGroep");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkGewassen)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkGewassen_tblVersie");
        });

        modelBuilder.Entity<LnkKunstmest>(entity =>
        {
            entity.ToTable("lnkKunstmest");

            entity.HasIndex(e => new { e.CodeMeststof, e.VersieId }, "IX_lnkKunstmest").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.KunstmestGroepId).HasColumnName("KunstmestGroepID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.KunstmestGroep).WithMany(p => p.LnkKunstmest)
                .HasForeignKey(d => d.KunstmestGroepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkKunstmest_tblKunstmestGroep");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkKunstmest)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkKunstmest_tblVersie");
        });

        modelBuilder.Entity<LnkKunstmestGroepStreek>(entity =>
        {
            entity.ToTable("lnkKunstmestGroepStreek");

            entity.HasIndex(e => new { e.KunstmestGroepId, e.LandbouwStreekId, e.VersieId }, "IX_lnkKunstmestGroepStreek").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Ec).HasColumnName("EC");
            entity.Property(e => e.KunstmestGroepId).HasColumnName("KunstmestGroepID");
            entity.Property(e => e.LandbouwStreekId).HasColumnName("LandbouwStreekID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.KunstmestGroep).WithMany(p => p.LnkKunstmestGroepStreek)
                .HasForeignKey(d => d.KunstmestGroepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkKunstmestGroepStreek_lutKunstmestGroep");

            entity.HasOne(d => d.LandbouwStreek).WithMany(p => p.LnkKunstmestGroepStreek)
                .HasForeignKey(d => d.LandbouwStreekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkKunstmestGroepStreek_lutLandbouwstreek");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkKunstmestGroepStreek)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkKunstmestGroepStreek_tblVersie");
        });

        modelBuilder.Entity<LnkMestDierPlaat>(entity =>
        {
            entity.ToTable("lnkMestDierPlaats");

            entity.HasIndex(e => new { e.DierCategorieId, e.MestTypeId, e.ToedieningsPlaatsId, e.VersieId }, "IX_lnkMestDierPlaats").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.DierCategorieId).HasColumnName("DierCategorieID");
            entity.Property(e => e.MestTypeId).HasColumnName("MestTypeID");
            entity.Property(e => e.ToedieningsPlaatsId).HasColumnName("ToedieningsPlaatsID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierCategorie).WithMany(p => p.LnkMestDierPlaat)
                .HasForeignKey(d => d.DierCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestDierPlaats_lutDierCategorie");

            entity.HasOne(d => d.MestType).WithMany(p => p.LnkMestDierPlaat)
                .HasForeignKey(d => d.MestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestDierPlaats_lutMestType");

            entity.HasOne(d => d.ToedieningsPlaats).WithMany(p => p.LnkMestDierPlaat)
                .HasForeignKey(d => d.ToedieningsPlaatsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestDierPlaats_lutToedieningsPlaats");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkMestDierPlaat)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestDierPlaats_tblVersie");
        });

        modelBuilder.Entity<LnkMestTechniekPlaat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblToedieningsTechniek");

            entity.ToTable("lnkMestTechniekPlaats");

            entity.HasIndex(e => new { e.MestTypeId, e.ToedieningsPlaatsId, e.ToedieningsTechniekId, e.VersieId }, "IX_lnkMestTechniekPlaats").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Ec).HasColumnName("EC");
            entity.Property(e => e.MestTypeId).HasColumnName("MestTypeID");
            entity.Property(e => e.ToedieningsPlaatsId).HasColumnName("ToedieningsPlaatsID");
            entity.Property(e => e.ToedieningsTechniekId).HasColumnName("ToedieningsTechniekID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.MestType).WithMany(p => p.LnkMestTechniekPlaat)
                .HasForeignKey(d => d.MestTypeId)
                .HasConstraintName("FK_lnkMestTechniekPlaats_lutMestType");

            entity.HasOne(d => d.ToedieningsPlaats).WithMany(p => p.LnkMestTechniekPlaat)
                .HasForeignKey(d => d.ToedieningsPlaatsId)
                .HasConstraintName("FK_lnkMestTechniekPlaats_lutToedieningsPlaats");

            entity.HasOne(d => d.ToedieningsTechniek).WithMany(p => p.LnkMestTechniekPlaat)
                .HasForeignKey(d => d.ToedieningsTechniekId)
                .HasConstraintName("FK_lnkMestTechniekPlaats_lutToedieningsTechniek");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkMestTechniekPlaat)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestTechniekPlaats_tblVersie");
        });

        modelBuilder.Entity<LnkMestToedieningsEmissy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lnkToedieningsTechniekDierCategorie");

            entity.ToTable("lnkMestToedieningsEmissies");

            entity.HasIndex(e => new { e.DierCategorieId, e.MestTypeId, e.VersieId }, "IX_lnkMestToedieningsEmissies").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.DierCategorieId).HasColumnName("DierCategorieID");
            entity.Property(e => e.MestTypeId).HasColumnName("MestTypeID");
            entity.Property(e => e.MinNfractie).HasColumnName("MinNFractie");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierCategorie).WithMany(p => p.LnkMestToedieningsEmissie)
                .HasForeignKey(d => d.DierCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestToedieningsEmissies_lutDierCategorie");

            entity.HasOne(d => d.MestType).WithMany(p => p.LnkMestToedieningsEmissie)
                .HasForeignKey(d => d.MestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestToedieningsEmissies_lutMestType");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkMestToedieningsEmissie)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkMestToedieningsEmissies_tblVersie");
        });

        modelBuilder.Entity<LnkStalDierSubCategorie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lnkStalTypeDierSubCategorie");

            entity.ToTable("lnkStalDierSubCategorie");

            entity.HasIndex(e => new { e.DierSubCategorieId, e.StalId, e.VersieId }, "IX_lnkStalTypeDierSubCategorie").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DierSubCategorieId).HasColumnName("DierSubCategorieID");
            entity.Property(e => e.EcN2Opslag).HasColumnName("EC_N2_Opslag");
            entity.Property(e => e.EcN2oOpslag).HasColumnName("EC_N2O_Opslag");
            entity.Property(e => e.EcNh3Opslag).HasColumnName("EC_NH3_Opslag");
            entity.Property(e => e.EcNoOpslag).HasColumnName("EC_NO_Opslag");
            entity.Property(e => e.Ecn2mm).HasColumnName("ECN2MM");
            entity.Property(e => e.Ecn2omm).HasColumnName("ECN2OMM");
            entity.Property(e => e.Ecn2ovm).HasColumnName("ECN2OVM");
            entity.Property(e => e.Ecn2vm).HasColumnName("ECN2VM");
            entity.Property(e => e.Ecnomm).HasColumnName("ECNOMM");
            entity.Property(e => e.Ecnovm).HasColumnName("ECNOVM");
            entity.Property(e => e.Efnh3).HasColumnName("EFNH3");
            entity.Property(e => e.MestNaam).HasMaxLength(150);
            entity.Property(e => e.StalId).HasColumnName("StalID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierSubCategorie).WithMany(p => p.LnkStalDierSubCategorie)
                .HasForeignKey(d => d.DierSubCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkStalTypeDierSubCategorie_tblDierSubCategorie");

            entity.HasOne(d => d.Stal).WithMany(p => p.LnkStalDierSubCategorie)
                .HasForeignKey(d => d.StalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkStalTypeDierSubCategorie_tblStalType");

            entity.HasOne(d => d.Versie).WithMany(p => p.LnkStalDierSubCategorie)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lnkStalDierSubCategorie_tblVersie");
        });

        modelBuilder.Entity<LutCheckType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lutTypeCheck");

            entity.ToTable("lutCheckType");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutCheckType").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutCheckType)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutCheckType_tblVersie");
        });

        modelBuilder.Entity<LutDierCategorie>(entity =>
        {
            entity.ToTable("lutDierCategorie");

            entity.HasIndex(e => new { e.Code, e.VersieId }, "IX_lutDierCategorie_Code").IsUnique();

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutDierCategorie_Naam").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutDierCategorie)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutDierCategorie_tblVersie");
        });

        modelBuilder.Entity<LutGewasGroep>(entity =>
        {
            entity.ToTable("lutGewasGroep");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutGewasGroep").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.ToedieningsPlaatsId).HasColumnName("ToedieningsPlaatsID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.ToedieningsPlaats).WithMany(p => p.LutGewasGroep)
                .HasForeignKey(d => d.ToedieningsPlaatsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutGewasGroep_lutToedieningsPlaats");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutGewasGroep)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutGewasGroep_tblVersie");
        });

        modelBuilder.Entity<LutKunstmestGroep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblKunstmestGroep");

            entity.ToTable("lutKunstmestGroep");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutKunstmestGroep)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblKunstmestGroep_tblVersie");
        });

        modelBuilder.Entity<LutLandbouwStreek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lutLandbouwstreek");

            entity.ToTable("lutLandbouwStreek");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutLandbouwstreek").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutLandbouwStreek)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutLandbouwstreek_tblVersie");
        });

        modelBuilder.Entity<LutMestType>(entity =>
        {
            entity.ToTable("lutMestType");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutMestType").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutMestType)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutMestType_tblVersie");
        });

        modelBuilder.Entity<LutMestverwerkingsTechniek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lutMestverwerkingsTechnieken");

            entity.ToTable("lutMestverwerkingsTechniek");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutMestverwerkingsTechnieken").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Ec).HasColumnName("EC");
            entity.Property(e => e.Naam).HasMaxLength(150);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");
            entity.Property(e => e.ZoekTermen).HasMaxLength(200);

            entity.HasOne(d => d.Versie).WithMany(p => p.LutMestverwerkingsTechniek)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutMestverwerkingsTechniek_tblVersie");
        });

        modelBuilder.Entity<LutStalType>(entity =>
        {
            entity.ToTable("lutStalType");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutStalType").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutStalType)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutStalType_tblVersie");
        });

        modelBuilder.Entity<LutToedieningsPlaat>(entity =>
        {
            entity.ToTable("lutToedieningsPlaats");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutToedieningsPlaats").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.MaxNtotaalPerHa).HasColumnName("MaxNTotaalPerHa");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutToedieningsPlaat)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutToedieningsPlaats_tblVersie");
        });

        modelBuilder.Entity<LutToedieningsTechniek>(entity =>
        {
            entity.ToTable("lutToedieningsTechniek");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutToedieningsTechniek").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.LutToedieningsTechniek)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutToedieningsTechniek_tblVersie");
        });

        modelBuilder.Entity<MvwUitbatingActiviteit>(entity =>
        {
            entity.ToTable("MVW_UITBATING_ACTIVITEIT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnderTypeActiviteit)
                .HasMaxLength(100)
                .HasColumnName("ANDER_TYPE_ACTIVITEIT");
            entity.Property(e => e.IndBiologie)
                .HasMaxLength(1)
                .HasColumnName("IND_BIOLOGIE");
            entity.Property(e => e.IndChampi)
                .HasMaxLength(1)
                .HasColumnName("IND_CHAMPI");
            entity.Property(e => e.IndCompdrog)
                .HasMaxLength(1)
                .HasColumnName("IND_COMPDROG");
            entity.Property(e => e.IndNgasProductie)
                .HasMaxLength(1)
                .HasColumnName("IND_NGAS_PRODUCTIE");
            entity.Property(e => e.IndNh4Spuiwater)
                .HasMaxLength(1)
                .HasColumnName("IND_NH4_SPUIWATER");
            entity.Property(e => e.IndPotgrond)
                .HasMaxLength(1)
                .HasColumnName("IND_POTGROND");
            entity.Property(e => e.IndSubstrt)
                .HasMaxLength(1)
                .HasColumnName("IND_SUBSTRT");
            entity.Property(e => e.IndTuinaan)
                .HasMaxLength(1)
                .HasColumnName("IND_TUINAAN");
            entity.Property(e => e.IndVergist)
                .HasMaxLength(1)
                .HasColumnName("IND_VERGIST");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.UitbatersnummerFict).HasColumnName("UITBATERSNUMMER_FICT");
            entity.Property(e => e.UitbatingsnummerFict).HasColumnName("UITBATINGSNUMMER_FICT");
        });

        modelBuilder.Entity<MvwUitbatingAdressen>(entity =>
        {
            entity.ToTable("MVW_UITBATING_ADRESSEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoNisFusiegemeente).HasColumnName("CO_NIS_FUSIEGEMEENTE");
            entity.Property(e => e.DaBeginIe)
                .HasColumnType("datetime")
                .HasColumnName("DA_BEGIN_IE");
            entity.Property(e => e.DaEindeIe)
                .HasColumnType("datetime")
                .HasColumnName("DA_EINDE_IE");
            entity.Property(e => e.LandCoPostGemExploitatieUit)
                .HasMaxLength(100)
                .HasColumnName("LAND_CO_POST_GEM_EXPLOITATIE_UIT");
            entity.Property(e => e.OmsFusiegemeente)
                .HasMaxLength(255)
                .HasColumnName("OMS_FUSIEGEMEENTE");
            entity.Property(e => e.StraatNrBusExploitatieUitbat)
                .HasMaxLength(100)
                .HasColumnName("STRAAT_NR_BUS_EXPLOITATIE_UITBAT");
            entity.Property(e => e.UitbatersnummerFict).HasColumnName("UITBATERSNUMMER_FICT");
            entity.Property(e => e.UitbatingsnummerFict).HasColumnName("UITBATINGSNUMMER_FICT");
        });

        modelBuilder.Entity<SpatialRefSy>(entity =>
        {
            entity.HasKey(e => e.Srid).HasName("PK__spatial___36B11BD5628DF71C");

            entity.ToTable("spatial_ref_sys");

            entity.Property(e => e.Srid)
                .ValueGeneratedNever()
                .HasColumnName("srid");
            entity.Property(e => e.AuthName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("auth_name");
            entity.Property(e => e.AuthSrid).HasColumnName("auth_srid");
            entity.Property(e => e.Proj4text)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("proj4text");
            entity.Property(e => e.Srtext)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("srtext");
        });

        modelBuilder.Entity<Stallen>(entity =>
        {
            entity.ToTable("STALLEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AanBezettingStaltype).HasColumnName("AAN_BEZETTING_STALTYPE");
            entity.Property(e => e.AanStandplaatsen).HasColumnName("AAN_STANDPLAATSEN");
            entity.Property(e => e.CodeDiergroep)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERGROEP");
            entity.Property(e => e.CodeDiersoort)
                .HasMaxLength(10)
                .HasColumnName("CODE_DIERSOORT");
            entity.Property(e => e.CodeStaltype)
                .HasMaxLength(10)
                .HasColumnName("CODE_STALTYPE");
            entity.Property(e => e.DaProc)
                .HasColumnType("datetime")
                .HasColumnName("DA_PROC");
            entity.Property(e => e.JrProductie)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("JR_PRODUCTIE");
            entity.Property(e => e.NrExploitantFict).HasColumnName("NR_EXPLOITANT_FICT");
            entity.Property(e => e.NrExploitatieFict).HasColumnName("NR_EXPLOITATIE_FICT");
            entity.Property(e => e.NrLandbouwerFict).HasColumnName("NR_LANDBOUWER_FICT");
            entity.Property(e => e.OmsDiergroep)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERGROEP");
            entity.Property(e => e.OmsDiersoort)
                .HasMaxLength(100)
                .HasColumnName("OMS_DIERSOORT");
            entity.Property(e => e.OmsStaltype)
                .HasMaxLength(120)
                .HasColumnName("OMS_STALTYPE");
            entity.Property(e => e.PrcInStallen).HasColumnName("PRC_IN_STALLEN");
            entity.Property(e => e.PrcVloeibare).HasColumnName("PRC_VLOEIBARE");
        });

        modelBuilder.Entity<TblCheck>(entity =>
        {
            entity.ToTable("tblCheck");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.CheckTypeId).HasColumnName("CheckTypeID");
            entity.Property(e => e.KolomNaam).HasMaxLength(250);
            entity.Property(e => e.TabelNaam).HasMaxLength(250);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.CheckType).WithMany(p => p.TblCheck)
                .HasForeignKey(d => d.CheckTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCheck_lutCheckType");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblCheck)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCheck_tblVersie");
        });

        modelBuilder.Entity<TblConvenant>(entity =>
        {
            entity.ToTable("tblConvenant");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.DierSubCategorieId).HasColumnName("DierSubCategorieID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierSubCategorie).WithMany(p => p.TblConvenant)
                .HasForeignKey(d => d.DierSubCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblConvenant_tblDierSubCategorie");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblConvenant)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblConvenant_tblVersie");
        });

        modelBuilder.Entity<TblDierSubCategorie>(entity =>
        {
            entity.ToTable("tblDierSubCategorie");

            entity.HasIndex(e => new { e.Code, e.VersieId }, "IX_tblDierSubCategorie_Code").IsUnique();

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_tblDierSubCategorie_Naam").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DierCategorieId).HasColumnName("DierCategorieID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierCategorie).WithMany(p => p.TblDierSubCategorie)
                .HasForeignKey(d => d.DierCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDierSubCategorie_tblDierSubCategorie");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblDierSubCategorie)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDierSubCategorie_tblVersie");
        });

        modelBuilder.Entity<TblGebruiker>(entity =>
        {
            entity.ToTable("tblGebruiker");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblPas>(entity =>
        {
            entity.ToTable("tblPAS", tb =>
                {
                    tb.HasTrigger("tblPASTrigger_DELETE");
                    tb.HasTrigger("tblPASTrigger_UPDATE");
                });

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_tblPAS").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.Passtal).HasColumnName("PASStal");
            entity.Property(e => e.Pasvoeding).HasColumnName("PASVoeding");
            entity.Property(e => e.Pasweide).HasColumnName("PASWeide");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblPas)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPAS_tblVersie");
        });

        modelBuilder.Entity<TblParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_lutParameters");

            entity.ToTable("tblParameter");

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_lutParameters").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Naam).HasMaxLength(50);
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblParameter)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lutParameter_tblVersie");
        });

        modelBuilder.Entity<TblRegressie>(entity =>
        {
            entity.ToTable("tblRegressie");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.DierSubCategorieId).HasColumnName("DierSubCategorieID");
            entity.Property(e => e.VersieId)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("VersieID");

            entity.HasOne(d => d.DierSubCategorie).WithMany(p => p.TblRegressie)
                .HasForeignKey(d => d.DierSubCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegressie_tblDierSubCategorie");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblRegressie)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegressie_tblVersie");
        });

        modelBuilder.Entity<TblRegressieRechte>(entity =>
        {
            entity.ToTable("tblRegressieRechte");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.A).HasColumnName("a");
            entity.Property(e => e.B).HasColumnName("b");
            entity.Property(e => e.DierSubCategorieId).HasColumnName("DierSubCategorieID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.DierSubCategorie).WithMany(p => p.TblRegressieRechte)
                .HasForeignKey(d => d.DierSubCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegressieRechte_tblDierSubCategorie");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblRegressieRechte)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRegressieRechte_tblVersie");
        });

        modelBuilder.Entity<TblStal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblStalType");

            entity.ToTable("tblStal", tb =>
                {
                    tb.HasTrigger("tblStalTrigger_DELETE");
                    tb.HasTrigger("tblStalTrigger_UPDATE");
                });

            entity.HasIndex(e => new { e.Naam, e.VersieId }, "IX_tblStalType").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.MestTypeId).HasColumnName("MestTypeID");
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Omschrijving).HasMaxLength(250);
            entity.Property(e => e.StalTypeId).HasColumnName("StalTypeID");
            entity.Property(e => e.VersieId).HasColumnName("VersieID");

            entity.HasOne(d => d.MestType).WithMany(p => p.TblStal)
                .HasForeignKey(d => d.MestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStalType_lutMestType");

            entity.HasOne(d => d.StalType).WithMany(p => p.TblStal)
                .HasForeignKey(d => d.StalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStal_lutStalType");

            entity.HasOne(d => d.Versie).WithMany(p => p.TblStal)
                .HasForeignKey(d => d.VersieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStal_tblVersie");
        });

        modelBuilder.Entity<TblVersie>(entity =>
        {
            entity.ToTable("tblVersie", tb =>
                {
                    tb.HasTrigger("tblVersieTrigger_DELETE");
                    tb.HasTrigger("tblVersieTrigger_UPDATE");
                });

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.GebruikerId).HasColumnName("GebruikerID");
            entity.Property(e => e.Naam).HasMaxLength(50);

            entity.HasOne(d => d.Gebruiker).WithMany(p => p.TblVersies)
                .HasForeignKey(d => d.GebruikerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblVersie_tblGebruiker");
        });

        modelBuilder.Entity<VervoerMad>(entity =>
        {
            entity.ToTable("VERVOER_MAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoGewestLosplaats)
                .HasMaxLength(25)
                .HasColumnName("CO_GEWEST_LOSPLAATS");
            entity.Property(e => e.CoIdentEenhRolAanbieder)
                .HasMaxLength(25)
                .HasColumnName("CO_IDENT_EENH_ROL_AANBIEDER");
            entity.Property(e => e.CoIdentEenhRolAfnemer)
                .HasMaxLength(25)
                .HasColumnName("CO_IDENT_EENH_ROL_AFNEMER");
            entity.Property(e => e.CoMeststof).HasColumnName("CO_MESTSTOF");
            entity.Property(e => e.CoMesttype)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTTYPE");
            entity.Property(e => e.CoMestvorm)
                .HasMaxLength(2)
                .HasColumnName("CO_MESTVORM");
            entity.Property(e => e.DatumAflading)
                .HasColumnType("datetime")
                .HasColumnName("DATUM_AFLADING");
            entity.Property(e => e.GwKgN).HasColumnName("GW_KG_N");
            entity.Property(e => e.JrVervoer).HasColumnName("JR_VERVOER");
            entity.Property(e => e.NrExploitantAfnFict).HasColumnName("NR_EXPLOITANT_AFN_FICT");
            entity.Property(e => e.NrExploitantAnbFict).HasColumnName("NR_EXPLOITANT_ANB_FICT");
            entity.Property(e => e.NrExploitatieAfnFict).HasColumnName("NR_EXPLOITATIE_AFN_FICT");
            entity.Property(e => e.NrExploitatieAnbFict).HasColumnName("NR_EXPLOITATIE_ANB_FICT");
            entity.Property(e => e.NrLandbouwerAfnFict).HasColumnName("NR_LANDBOUWER_AFN_FICT");
            entity.Property(e => e.NrLandbouwerAnbFict).HasColumnName("NR_LANDBOUWER_ANB_FICT");
            entity.Property(e => e.UitbatersnummerAfnFict).HasColumnName("UITBATERSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatersnummerAnbFict).HasColumnName("UITBATERSNUMMER_ANB_FICT");
            entity.Property(e => e.UitbatingsnummerAfnFict).HasColumnName("UITBATINGSNUMMER_AFN_FICT");
            entity.Property(e => e.UitbatingsnummerAnbFict).HasColumnName("UITBATINGSNUMMER_ANB_FICT");
        });

        modelBuilder.Entity<Vlops1000mRooster>(entity =>
        {
            entity.HasKey(e => e.OgrFid);

            entity.ToTable("vlops_1000m_rooster");

            entity.Property(e => e.OgrFid).HasColumnName("ogr_fid");
            entity.Property(e => e.Id)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Isvlopscel)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("isvlopscel");
        });

        modelBuilder.Entity<Vlops250mRooster>(entity =>
        {
            entity.HasKey(e => e.OgrFid);

            entity.ToTable("vlops_250m_rooster");

            entity.Property(e => e.OgrFid).HasColumnName("ogr_fid");
            entity.Property(e => e.Id)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Isvlopscel)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("isvlopscel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
