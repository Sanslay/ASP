using PamWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pam.Web.Models
{
  [Bind(Exclude = "Application")]
  public class IndexModel
  {
    // données de portée application
    public ApplicationModel Application { get; set; }

    // valeurs postées
    [Display(Name = "Employé")]

    public string SS { get; set; }
    [Display(Name = "Heures travaillées")]

    [Required(ErrorMessage = "Information requise")]
    [UIHint("Decimal")]
    [Range(1, 400, ErrorMessage = "Information incorrecte")]
    public double HeuresTravaillées { get; set; }

    [Display(Name = "Jours travaillés")]
    [Required(ErrorMessage = "Information requise")]
    [UIHint("Decimal")]
    [Range(1, 31, ErrorMessage = "Information incorrecte")]
    public double JoursTravaillés { get; set; }
  }
}