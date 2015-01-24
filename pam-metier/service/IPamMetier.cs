using Pam.EF5.Entites;
using pam_metier.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_metier.service
{
  public interface IPamMetier
  {
    // liste de toutes les identités des employés
    Employe[] GetAllIdentitesEmployes();
    // ------- le calcul du salaire
    FeuilleSalaire GetSalaire(string ss, double heuresTravaillées, int joursTravaillés);
  }
}
