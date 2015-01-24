using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.EF5.Entites
{
  [Table("INDEMNITES")]
  public class Indemnites
  {
    [Key]
    [Column("ID")]
    public int Id { get; set; }
     [Column("INDICE")]
    public int Indice { get; set; }
     [Column("BASE_HEURE")]
    public double BaseHeure { get; set; }
     [Column("ENTRETIEN_JOUR")]
    public double EntretienJour { get; set; }
     [Column("REPAS_JOUR")]
    public double RepasJour { get; set; }
     [Column("INDEMNITES_CP")]
    public double IndemnitesCp { get; set; }
    [ConcurrencyCheck]
     [Column("VERSIONING")]
    public int Versioning { get; set; }
    // signature
    public override string ToString()
    {
      return string.Format("Indemnités[{0},{1},{2},{3},{4}, {5}, {6}]", Id, Versioning,
      Indice, BaseHeure, EntretienJour, RepasJour, IndemnitesCp);
    }
  }
}