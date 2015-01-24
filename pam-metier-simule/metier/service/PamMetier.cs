using Pam.Metier.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.Metier.Service
{
  public class PamMetier : IPamMetier
  {
    // liste des employés en cache
    public Employe[] Employes { get; set; }
    // employés indexés par leur n° SS
    private IDictionary<string, Employe> dicEmployes = new Dictionary<string, Employe>();
    // liste des employés
    public Employe[] GetAllIdentitesEmployes()
    {
      if (Employes == null)
      {
        // on crée un tableau de trois employés
        Employes = new Employe[3];
        Employes[0] = new Employe()
        {
          SS = "254104940426058",
          Nom = "Jouveinal",
          Prenom = "Marie",
          Adresse = "5 rue des oiseaux",
          Ville = "St Corentin",
          CodePostal = "49203",
          Indemnites = new Indemnites()
          {
            Indice = 2,
            BaseHeure = 2.1,
            EntretienJour =
              2.1,
            RepasJour = 3.1,
            IndemnitesCp = 15
          }
        };
        dicEmployes.Add(Employes[0].SS, Employes[0]);
        Employes[1] = new Employe()
        {
          SS = "260124402111742",
          Nom = "Laverti",
          Prenom = "Justine",
          Adresse = "La brûlerie",
          Ville = "St Marcel",
          CodePostal = "49014",
          Indemnites = new Indemnites()
          {
            Indice = 1,
            BaseHeure = 1.93,
            EntretienJour =
              2,
            RepasJour = 3,
            IndemnitesCp = 12
          }
        };
        dicEmployes.Add(Employes[1].SS, Employes[1]);
        // un employé fictif qui ne sera pas mis dans le dictionnaire
        // afin de simuler un employé inexistant
        Employes[2] = new Employe()
        {
          SS = "XX",
          Nom = "X",
          Prenom = "X",
          Adresse = "X",
          Ville = "X",
          CodePostal = "X",
          Indemnites = new Indemnites()
          {
            Indice = 0,
            BaseHeure = 0,
            EntretienJour = 0,
            RepasJour = 0,
            IndemnitesCp = 0
          }
        };
      }
      // on rend la liste des employés
      return Employes;
    }
    // calcul salaire
    public FeuilleSalaire GetSalaire(string ss, double heuresTravaillées, int joursTravaillés)
    {
      // on récupère l'employé de n° SS
      Employe e = dicEmployes.ContainsKey(ss) ? dicEmployes[ss] : null;
      // existe ?
      if (e == null)
      {
        throw new PamException(string.Format("L'employé de n° SS [{0}] n'existe pas", ss), 10);
      }
      // on rend une feuille de salaire fictive
      return new FeuilleSalaire()
      {
        Employe = e,
        Cotisations = new Cotisations()
        {
          CsgRds = 3.49,
          Csgd = 6.15,
          Secu = 9.38,
          Retraite = 7.88
        },
        ElementsSalaire = new ElementsSalaire()
        {
          CotisationsSociales = 100,
          IndemnitesEntretien = 100,
          IndemnitesRepas = 100,
          SalaireBase = 100,
          SalaireNet = 100
        }
      };
    }
  }
}