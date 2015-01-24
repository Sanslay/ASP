using Pam.EF5.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.Models
{
  public class DbPamContext : DbContext
  {
    public DbSet<Employe> Employes { get; set; }
    public DbSet<Cotisations> Cotisations { get; set; }
    public DbSet<Indemnites> Indemnites { get; set; }
  }
}