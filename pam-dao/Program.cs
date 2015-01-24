using Pam.EF5.Entites;
using pam_dao.dao.service;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pam_dao
{
  public class Program
  {
    public static void Main()
    {
      try
      {
        // instanciation couche [dao]
        IPamDao pamDao = (IPamDao)ContextRegistry.GetContext().GetObject("pamdao");
        // liste des identités des employés
        foreach (Employe Employe in pamDao.GetAllIdentitesEmployes())
        {
          Console.WriteLine(Employe.ToString());
        }
        // un employé avec ses indemnités
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Employé n° 254104940426058");
        Console.WriteLine(pamDao.GetEmploye("254104940426058"));
        Console.WriteLine("------------------------------------");
        // un employé qui n'existe pas
        Employe employe = pamDao.GetEmploye("xx");
        Console.WriteLine("Employé n° xx");
        Console.WriteLine((employe == null ? "null" : employe.ToString()));
        Console.WriteLine("------------------------------------");
        // liste des cotisations
        Cotisations cotisations = pamDao.GetCotisations();
        Console.WriteLine(cotisations.ToString());
      }
      catch (Exception ex)
      {
        // affichage exception
        Console.WriteLine(ex.ToString());
      }
      //pause
      Console.ReadLine();
    }
  }
}