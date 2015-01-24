using Pam.Metier.Entites;
using Pam.Metier.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.Metier.Tests
{
  class Program
  {
    public static void Main()
    {
      // instanciation couche [métier]
      IPamMetier pamMetier = new PamMetier();
      // liste des employés
      Employe[] employes = pamMetier.GetAllIdentitesEmployes();
      Console.WriteLine("Liste des employés--------------------");
      foreach (Employe e in employes)
      {
        Console.WriteLine(e);
      }
      // calculs de feuilles de salaire
      Console.WriteLine("Calculs de feuilles de salaire-----------------");
      Console.WriteLine(pamMetier.GetSalaire(employes[0].SS, 30, 5));
      Console.WriteLine(pamMetier.GetSalaire(employes[1].SS, 150, 20));
      try
      {
        Console.WriteLine(pamMetier.GetSalaire(employes[2].SS, 150, 20));
      }
      catch (PamException ex)
      {
        Console.WriteLine(string.Format("PamException : {0}", ex.Message));
      }
    }
  }
}
