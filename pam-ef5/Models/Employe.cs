using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.EF5.Entites
{
  [Table("EMPLOYES")]
  public class Employe
  {
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SS")]
    public string SS { get; set; }
   
    [Column("NOM")]
    public string Nom { get; set; }
    [Column("PRENOM")]
    public string Prenom { get; set; }
    [Column("ADRESSE")]
    public string Adresse { get; set; }
    [Column("VILLE")]
    public string Ville { get; set; }
    [Column("CP")]
    public string CodePostal { get; set; }

    [Column("INDEMNITE_ID")]
    public int IndemniteId { get; set; }
    [ForeignKey("IndemniteId")]
    public Indemnites Indemnites { get; set; }

    [ConcurrencyCheck]
    [Column("VERSIONING")]
    public int Versioning { get; set; }
    // signature
    public override string ToString()
    {
      return string.Format("Employé[{0},{1},{2},{3},{4},{5}, {6}, {7}]", Id, Versioning,
      SS, Nom, Prenom, Adresse, Ville, CodePostal);
    }
  }
}