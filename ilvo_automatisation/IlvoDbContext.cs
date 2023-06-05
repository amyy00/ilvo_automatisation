using ilvo_automatisation.Models;
using Microsoft.EntityFrameworkCore;
using ilvo_automatisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilvo_automatisation
{
    public class IlvoDbContext : DbContext
    {
        public IlvoDbContext(DbContextOptions<IlvoDbContext> options) : base(options)
        {

        }

        private DbSet<TblStal> TblStal => Set<TblStal>();
        private DbSet<LnkGewassen> LnkGewassen => Set<LnkGewassen>();
        private DbSet<TblPa> TblPas => Set<TblPa>();
        private DbSet<TblVersie> TblVersie => Set<TblVersie>();
    }
}
