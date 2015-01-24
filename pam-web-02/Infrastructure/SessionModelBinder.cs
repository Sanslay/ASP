using System.Web.Mvc;
namespace Exemple_02.Infrastructure
{
public class SessionModelBinder : IModelBinder
{
  public object BindModel(ControllerContext controllerContext, ModelBindingContext
bindingContext)
  {
    // on rend les données de portée [Session]
    return controllerContext.HttpContext.Session["data"];
  }
}
}