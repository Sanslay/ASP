using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace pam_web_01.Infrastructure
{
  public class Static
  {
    // liste des messages d'erreur d'une exception
    public static List<string> GetErreursForException(Exception ex)
    {
      List<string> erreurs = new List<string>();
      while (ex != null)
      {
        erreurs.Add(ex.Message);
        ex = ex.InnerException;
      }
      return erreurs;
    }
    // liste des messages d'erreur liés à un modèle invalide
    public static List<string> GetErreursForModel(ModelStateDictionary état)
    {
      List<string> erreurs = new List<string>();
      if (!état.IsValid)
      {
        foreach (ModelState modelState in état.Values)
        {
          foreach (ModelError error in modelState.Errors)
          {
            erreurs.Add(getErrorMessageFor(error));
          }
        }
      }
      return erreurs;
    }
    // le message d'erreur lié à un élément du modèle de l'action
    static private string getErrorMessageFor(ModelError error)
    {
      if (error.ErrorMessage != null && error.ErrorMessage.Trim() != string.Empty)
      {
        return error.ErrorMessage;
      }
      if (error.Exception != null && error.Exception.InnerException == null &&
      error.Exception.Message != string.Empty)
      {
        return error.Exception.Message;
      }
      if (error.Exception != null && error.Exception.InnerException != null &&
      error.Exception.InnerException.Message != string.Empty)
      {
        return error.Exception.InnerException.Message;
      }
      return string.Empty;
    }
  }
}