using Pam.EF5.Entites;
using Pam.Models;
using pam_dao.dao.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_dao.dao.service
{
  public class PamDaoEF5 : IPamDao
  {
    // champs privés
    private Cotisations cotisations;
    private Employe[] employes;
    // Constructeur
    public PamDaoEF5()
    {
      // cotisation
      try
      {

        using (var context = new DbPamContext())
        {

            employes = context.Employes.ToArray();
            int IdCotisation =11;
            cotisations = context.Cotisations.Single<Cotisations>(c => c.Id == IdCotisation);

        }


      }
      catch (Exception e)
      {
        throw new PamException("Erreur système lors de la construction de la couche [DAO]",e, 1);
      }
    }
    // GetCotisations
    public Cotisations GetCotisations()
    {
      return cotisations;
    }
    // GetAllIdentitesEmploye
    public Employe[] GetAllIdentitesEmployes()
    {
      return employes;
    }
    // GetEmploye
    public Employe GetEmploye(string SS)
    {

      // affichage dépendance
      try
      {
        Employe empl = new Employe();
        using (var context = new DbPamContext())
        {
          empl = context.Employes.Include("Indemnites").Single<Employe>(c => c.SS == SS);
          
        }
        return empl;

      }


      catch (Exception e)
      {
        return null;
        throw new PamException(string.Format("Erreur système lors de la recherche de l'employé [{0}]", SS), e, 2);
        
      }
    }
  }
}

