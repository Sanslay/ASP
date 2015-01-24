using Pam.Metier.Entites;
using Pam.Web.Models;
using pam_web_01.Infrastructure;
using PamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace Pam.Web.Controllers
{
  public class PamController : Controller
  {
    [HttpGet]
    public ViewResult Index(ApplicationModel application)
    {
      // erreur d'initialisation ?
      if (application.InitException != null)
      {
        // page d'erreurs sans menu
        return View("InitFailed", Static.GetErreursForException(application.InitException));
      }
      // pas d'erreur
      return View(new IndexModel() { Application = application });
    }

    [HttpPost]

    public PartialViewResult FaireSimulation(ApplicationModel application, SessionModel session, FormCollection data)
    {
      // création du modèle de l'action
      IndexModel modèle = new IndexModel() { Application = application };
      // on essaie de récupérer les valeurs postées dans le modèle
      TryUpdateModel(modèle, data);
      // modèle valide ?
      if (!ModelState.IsValid)
      {
        // on affiche la page d'erreurs
        return PartialView("Erreurs", Static.GetErreursForModel(ModelState));
      }
      // on calcule le salaire
      FeuilleSalaire feuilleSalaire = null;
      Exception exception = null;
      try
      {
        // calcul salaire
        feuilleSalaire = application.PamMetier.GetSalaire(modèle.SS, modèle.HeuresTravaillées, (int)modèle.JoursTravaillés);
        // on crée une simulation et on la met dans la session
        session.Simulation = new Simulation() { Num = session.NumNextSimulation, FeuilleSalaire = feuilleSalaire, HeuresTravaillées = modèle.HeuresTravaillées, JoursTravaillés = (int)modèle.JoursTravaillés };

      }
      catch (Exception ex)
      {
        exception = ex;
      }
      // erreur ?
      if (exception != null)
      {
        // on affiche la page d'erreurs
        return PartialView("Erreurs", Static.GetErreursForException(exception));
      }
      
      // on affiche la feuille de salaire
      return PartialView("Simulation", feuilleSalaire);
    }
    // enregistrer une simulation
    [HttpPost]
    public PartialViewResult EnregisterSimulation(SessionModel session)
    {
      // on enregistre la dernière simulation faite dans la liste des simulations de la session
      Simulation simula = new Simulation();

      simula = session.Simulation;
      session.Simulations.Add(simula);
      
      // on incrémente dans la session le n° de la prochaine simulation
      session.NumNextSimulation++;
      
      // on affiche la liste des simulations

      return PartialView("Simulations", session.Simulations);
    }
    public PartialViewResult RetirerSimulation(ApplicationModel application, SessionModel session, int num)
    {
      bool remove=false;
      int index = 0;
      Simulation s;
      string vue = "Simulations";
      while(remove==false && index <session.Simulations.Count)
      {
        
        s = session.Simulations[index];
        if (s.Num == num)
        {
          session.Simulations.Remove(s);
          remove=true;
        }
        index++;
      }

      return PartialView(vue, session.Simulations);
    }

    public PartialViewResult voirSimulations(SessionModel session)
    {
      string vue = "Simulations";
      
      return PartialView(vue, session.Simulations);
    }
    public PartialViewResult Formulaire(ApplicationModel application)
    {
      string vue = "Formulaire";
      IndexModel modèle = new IndexModel() { Application = application };
      return PartialView(vue, modèle);
    }
    public PartialViewResult TerminerSession(SessionModel session)
    {
      string vue = "Formulaire";
      Session.Abandon();

      return PartialView(vue, session.Simulation  );
    }

  }
}