using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pam.Metier.Entites;
using Pam.Metier.Service;
using System.Web.Mvc;
namespace PamWeb.Models
{
  public class ApplicationModel
  {
    // --- données de portée application ---
    public Employe[] Employes { get; set; }
    public IPamMetier PamMetier { get; set; }
    public SelectListItem[] EmployesItems { get; set; }
    public Exception InitException { get; set; }
  }
}