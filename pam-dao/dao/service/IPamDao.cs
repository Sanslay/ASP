using Pam.EF5.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_dao.dao.service
{
  public interface IPamDao
  {
    // liste de toutes les identités des employés
    Employe[] GetAllIdentitesEmployes();
    // un employé particulier avec ses indemnités
    Employe GetEmploye(string ss);
    // liste de toutes les cotisations
    Cotisations GetCotisations();
  }
}
