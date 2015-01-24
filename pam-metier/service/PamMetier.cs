using Pam.EF5.Entites;
using pam_dao.dao.entites;
using pam_dao.dao.service;
using pam_metier.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_metier.service
{
  public class PamMetier : IPamMetier
  {
    // référence sur la couche [DAO] initialisée par Spring
    public IPamDao PamDao { get; set; }
    // liste de toutes les identités des employés
    public Employe[] GetAllIdentitesEmployes()
    {
      return PamDao.GetAllIdentitesEmployes();

    }
    // un employé particulier avec ses indemnités
    public Employe GetEmploye(string ss)
    {
      return PamDao.GetEmploye(ss);
    }
    // les cotisations
    public Cotisations GetCotisations()
    {
      return PamDao.GetCotisations();
    }
    // calcul du salaire
    public FeuilleSalaire GetSalaire(string ss, double heuresTravaillées, int joursTravaillés)
    {
      Employe e = PamDao.GetEmploye(ss);
      Cotisations c = PamDao.GetCotisations();
      if (e == null)
      {
        throw new PamException("L'employé de n° [" + ss + "] n'existe pas", 40);
      }
          //Le meme calcule que en java
      else
      {
        Indemnites indemnite = e.Indemnites;
        double BaseHeure = indemnite.BaseHeure;
        double IndemnitesCP = indemnite.IndemnitesCp;
        double TxCSGRDS = c.CsgRds;
        double TxCSGD = c.Csgd;
        double TxSECU = c.Secu;
        double TxRETRAITE = c.Retraite;
        double EntretienJour = indemnite.EntretienJour;
        double RepasJour = indemnite.RepasJour;

        double SalaireBase = (heuresTravaillées * BaseHeure) * (1 + (IndemnitesCP / 100));

        SalaireBase = Math.Floor(SalaireBase * 100) / 100;
        double CSGRDS = SalaireBase * (TxCSGRDS / 100);
        CSGRDS = Math.Floor(CSGRDS * 100) / 100;
        double CSGD = SalaireBase * (TxCSGD / 100);
        CSGD = Math.Floor(CSGD * 100) / 100;
        double SECU = SalaireBase * (TxSECU / 100);
        SECU = Math.Floor(SECU * 100) / 100;
        double RETRAITE = SalaireBase * (TxRETRAITE / 100);
        RETRAITE = Math.Floor(RETRAITE * 100) / 100;
        double CotisationsSociales = (SalaireBase * (TxCSGRDS + TxCSGD + TxSECU + TxRETRAITE)) / 100;
        CotisationsSociales = Math.Floor(CotisationsSociales * 100) / 100;
        double IndemnitesEntretien = joursTravaillés * EntretienJour;
        IndemnitesEntretien = Math.Floor(IndemnitesEntretien * 100) / 100;
        double IndemnitesRepas = joursTravaillés * RepasJour;
        IndemnitesRepas = Math.Floor(IndemnitesRepas * 100) / 100;
        double Indemnites = joursTravaillés * (EntretienJour + RepasJour);
        Indemnites = Math.Floor(Indemnites * 100) / 100;
        double SalaireNet = SalaireBase - CotisationsSociales + Indemnites;
        SalaireNet = Math.Floor(SalaireNet * 100) / 100;

        ElementsSalaire elementsalaire = new ElementsSalaire() { SalaireBase = SalaireBase, CotisationsSociales = CotisationsSociales, IndemnitesEntretien = IndemnitesEntretien, IndemnitesRepas = IndemnitesRepas, SalaireNet = SalaireNet };

        FeuilleSalaire feuillesalaire = new FeuilleSalaire() { Employe = e, Cotisations = c, ElementsSalaire = elementsalaire };
        return feuillesalaire;
      }
    }
  }
}
