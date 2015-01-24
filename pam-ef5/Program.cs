using Pam.EF5.Entites;
using Pam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_ef5
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        using (var context = new DbPamContext())
        {
          // on affiche le contenu des tables
          Console.WriteLine("Liste des employés ----------------------------------------");
          foreach (Employe employe in context.Employes)
          {
            Console.WriteLine(employe);
          }
          Console.WriteLine("Liste des indemnités --------------------------------------");
          foreach (Indemnites indemnite in context.Indemnites)
          {
            Console.WriteLine(indemnite);
          }
          Console.WriteLine("Liste des cotisations -------------------------------------");
          foreach (Cotisations cotisations in context.Cotisations)
          {
            Console.WriteLine(cotisations);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return;
      }
    }
  }
}
