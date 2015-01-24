using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Pam.EF5.Entites
{
  [Table("COTISATIONS")]
  public class Cotisations
  {
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [Column("CSGRDS")]
    public double CsgRds { get; set; }
    [Column("CSGD")]
    public double Csgd { get; set; }
    [Column("SECU")]
    public double Secu { get; set; }
    [Column("RETRAITE")]
    public double Retraite { get; set; }
    [ConcurrencyCheck]
    [Column("VERSIONING")]
    public int Versioning { get; set; }
    // signature
    public override string ToString()
    {
      return string.Format("Cotisations[{0},{1},{2},{3}, {4}, {5}]", Id, Versioning,
      CsgRds, Csgd, Secu, Retraite);
    }
  }
}