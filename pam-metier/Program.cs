
using Pam.EF5.Entites;
using pam_dao.dao.entites;
using pam_metier.service;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_metier
{
    public class Program
    {
      public static void Main()
      {
        try
        {
          // instanciation couche [métier]
          IPamMetier pamMetier = ContextRegistry.GetContext().GetObject("pammetier") as
          IPamMetier;
          // liste des identités des employés
          Console.WriteLine("Employés -----------------------------");
          foreach (Employe Employe in pamMetier.GetAllIdentitesEmployes())
          {
            Console.WriteLine(Employe);
          }
          // calculs de feuilles de salaire
          Console.WriteLine("salaires -----------------------------");
          Console.WriteLine(pamMetier.GetSalaire("260124402111742", 30, 5));
          Console.WriteLine(pamMetier.GetSalaire("254104940426058", 150, 20));
          try
          {
            Console.WriteLine(pamMetier.GetSalaire("xx", 150, 20));
          }
          catch (PamException ex)
          {
            Console.WriteLine(string.Format("PamException : {0}", ex.Message));
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(string.Format("Exception : {0}, Exception interne : {1}",
          ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message));
        }
        // pause
        Console.ReadLine();
      }
    }
  }
