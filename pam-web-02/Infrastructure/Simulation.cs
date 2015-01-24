
using pam_metier.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pam_web_01.Infrastructure
{
  public class Simulation
  {
    // n° de la simulation
    public int Num { get; set; }
    // le nombre d'heures travaillées
    public double HeuresTravaillées { get; set; }
    // le nombre de jours travaillés
    public int JoursTravaillés { get; set; }
    // la feuille de salaire
    public FeuilleSalaire FeuilleSalaire { get; set; }
  }
}