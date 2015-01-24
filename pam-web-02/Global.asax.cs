using Exemple_02.Infrastructure;
using Pam.Web.Infrastructure;
using pam_metier.service;
using pam_web_01.Infrastructure;
using PamWeb.Models;
using Spring.Context.Support;
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace pam_web_01
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      // ----------Auto-généré
      AreaRegistration.RegisterAllAreas();
      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      // -------------------------------------------------------------------
      // ---------- configuration spécifique
      // -------------------------------------------------------------------

      // données de portée application
      ApplicationModel application = new ApplicationModel();
      Application["data"] = application;
      application.InitException = null;
      try
      {
        // instanciation couche [métier]
        application.PamMetier = ContextRegistry.GetContext().GetObject("pammetier") as IPamMetier;
      }
      catch (Exception ex)
      {
        application.InitException = ex;
      }
      //si pas d'erreur
      if (application.InitException == null)
      {
        // tableau des employés

        application.Employes = application.PamMetier.GetAllIdentitesEmployes();

        // éléments du combo des employés
        SelectListItem[] combo = new SelectListItem[application.Employes.Length];

        for (int i = 0; i < application.Employes.Length; i++)
        {
          combo[i] = new SelectListItem() { Value = application.Employes[i].Prenom + " " + application.Employes[i].Nom, Text = application.Employes[i].SS };
        }
        application.EmployesItems = combo;


      }

      // model binder pour [ApplicationModel]

      ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());
      ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());
    }
    protected void Session_Start()
    {
      // initialisation compteur
      Session["data"] = new SessionModel();
    }
  }
}